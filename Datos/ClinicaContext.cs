using Microsoft.EntityFrameworkCore;
using MiSalud.Entidades;
using Microsoft.Extensions.Configuration;

namespace MiSalud.Datos
{
    public class ClinicaContext : DbContext
    {
        // DbSets para las entidades de la base de datos
        public DbSet<Personal> Personal { get; set; }
        public DbSet<Especialidad> Especialidades { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<ConsultaServicio> ConsultasServicios { get; set; }
        public DbSet<CuotaPlanPago> CuotasPlanPago { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<FichaClinico> FichasClinico { get; set; }
        public DbSet<Habitacion> Habitaciones { get; set; }
        public DbSet<Hospitalizacion> Hospitalizaciones { get; set; }
        public DbSet<HospitalizacionServicio> HospitalizacionServicios { get; set; }
        public DbSet<HuellaDactilar> HuellasDactilares { get; set; }
        public DbSet<MetodoPago> MetodosPago { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<PlanPago> PlanesPago { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<TipoAlta> TiposAlta { get; set; }
        public DbSet<TipoHabitacion> TiposHabitacion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json", optional: true)
                    .AddEnvironmentVariables()
                    .Build();

                var connection = configuration.GetConnectionString("DefaultConnection");

                if (string.IsNullOrWhiteSpace(connection))
                {
                    connection = "Host=localhost;Database=MiSalud;Username=postgres;Password=1234";
                }

                optionsBuilder.UseNpgsql(connection);
            }
        }
    }
}


