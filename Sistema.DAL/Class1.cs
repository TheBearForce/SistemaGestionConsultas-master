using Sistema.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.DAL
{
    public class SistemaDbContext : DbContext

    {

        public SistemaDbContext(DbContextOptions<SistemaDbContext> options) : base(options) { }



        public DbSet<Paciente> Pacientes { get; set; }

        public DbSet<Doctor> Doctores { get; set; }

        public DbSet<Cita> Citas { get; set; }

    }

}