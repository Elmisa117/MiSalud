using Microsoft.EntityFrameworkCore;
using MiSalud.Entidades; // Ajusta esto al namespace donde están tus modelos

namespace MiSalud.Datos
{
    public class ClinicaContext : DbContext
    {
        public DbSet<Personal> Personal { get; set; }

        // Aquí puedes agregar otras tablas (DbSet)
        // public DbSet<Paciente> Pacientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Cambia la cadena de conexión según tu base de datos PostgreSQL
                optionsBuilder.UseNpgsql("Host=localhost;Database=MiSalud;Username=postgres;Password=1234");
            }
        }
    }
}


