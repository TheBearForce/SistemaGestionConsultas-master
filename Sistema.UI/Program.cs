// Sistema.UI (Consola) 

using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.DependencyInjection;

using Sistema.DAL;

using Sistema.Infraestructura;

using Sistema.BLL;

using Sistema.Model;

using System;

using System.Threading.Tasks;



class Program

{
    static async Task Main(string[] args)

     {

    var services = new ServiceCollection();



    services.AddDbContext<SistemaDbContext>(options =>

        options.UseInMemoryDatabase("ConsultasDB"));



    services.AddScoped<IUnitOfWork, UnitOfWork>();

    services.AddScoped<CitaService>();



    var serviceProvider = services.BuildServiceProvider();



    // Cargar datos iniciales (Paciente y Doctor) 

    var context = serviceProvider.GetRequiredService<SistemaDbContext>();



    context.Pacientes.Add(new Paciente

    {

        Id = 1,

        Nombre = "Juan Pérez",

        FechaNacimiento = new DateTime(1980, 5, 10),

        Telefono = "123456789"

    });



    context.Doctores.Add(new Doctor

    {

        Id = 1,

        Nombre = "Dra. López",

        Especialidad = "Cardiología"

    });



    context.SaveChanges();



    // Crear servicio de cita 

    var citaService = serviceProvider.GetRequiredService<CitaService>();



    // Crear nueva cita 

    var cita = new Cita

    {

        PacienteId = 1,

        DoctorId = 1,

        FechaHora = DateTime.Now.AddHours(1)

    };



    await citaService.CrearCitaAsync(cita);



    // Mostrar citas 

    var citas = await citaService.ObtenerCitasAsync();

    foreach (var c in citas)

    {

        Console.WriteLine($"Cita: Paciente={c.Paciente.Nombre}, Doctor={c.Doctor.Nombre}, Fecha={c.FechaHora}");

    }

} 

} 