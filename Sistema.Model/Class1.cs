using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Model
{
    public class Paciente

    {

        public int Id { get; set; }

        public string Nombre { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string Telefono { get; set; }

    }



    public class Doctor

    {

        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Especialidad { get; set; }

    }



    public class Cita

    {

        public int Id { get; set; }

        public int PacienteId { get; set; }

        public int DoctorId { get; set; }

        public DateTime FechaHora { get; set; }



        public Paciente Paciente { get; set; }

        public Doctor Doctor { get; set; }

    }

}