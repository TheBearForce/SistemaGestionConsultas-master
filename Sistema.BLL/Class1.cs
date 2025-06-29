using Sistema.Infraestructura;
using Sistema.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.BLL
{
    public class CitaService

    {

        private readonly IUnitOfWork _unitOfWork;



        public CitaService(IUnitOfWork unitOfWork)

        {

            _unitOfWork = unitOfWork;

        }



        public async Task<IEnumerable<Cita>> ObtenerCitasAsync()

        {

            return await _unitOfWork.Citas.GetAllAsync();

        }



        public async Task CrearCitaAsync(Cita cita)

        {

            // Validaciones de negocio opcionales 

            await _unitOfWork.Citas.AddAsync(cita);

            await _unitOfWork.SaveAsync();

        }

    }

}
