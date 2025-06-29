using Sistema.DAL;
using Sistema.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Infraestructura
{
    public interface IRepository<T> where T : class

    {

        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);

        Task AddAsync(T entity);

        void Update(T entity);

        void Delete(T entity);

    }



    public interface IUnitOfWork

    {

        IRepository<Paciente> Pacientes { get; }

        IRepository<Doctor> Doctores { get; }

        IRepository<Cita> Citas { get; }

        Task<int> SaveAsync();

    }



    public class Repository<T> : IRepository<T> where T : class

    {

        protected readonly SistemaDbContext _context;

        protected readonly DbSet<T> _dbSet;



        public Repository(SistemaDbContext context)

        {

            _context = context;

            _dbSet = _context.Set<T>();

        }



        public virtual async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();



        public async Task<T> GetByIdAsync(int id) => await _dbSet.FindAsync(id);



        public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);



        public void Update(T entity) => _dbSet.Update(entity);



        public void Delete(T entity) => _dbSet.Remove(entity);

    }



    public class CitaRepository : Repository<Cita>

    {

        public CitaRepository(SistemaDbContext context) : base(context) { }



        public override async Task<IEnumerable<Cita>> GetAllAsync()

        {

            return await _context.Citas

                .Include(c => c.Paciente)

                .Include(c => c.Doctor)

                .ToListAsync();

        }

    }



    public class UnitOfWork : IUnitOfWork

    {

        private readonly SistemaDbContext _context;



        public IRepository<Paciente> Pacientes { get; }

        public IRepository<Doctor> Doctores { get; }

        public IRepository<Cita> Citas { get; }



        public UnitOfWork(SistemaDbContext context)

        {

            _context = context;

            Pacientes = new Repository<Paciente>(context);

            Doctores = new Repository<Doctor>(context);

            Citas = new CitaRepository(context);

        }



        public async Task<int> SaveAsync() => await _context.SaveChangesAsync();

    }

}
