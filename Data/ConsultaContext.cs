using CiudadanosSanos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace CiudadanosSanos.Data
{
    public class ConsultaContext : DbContext
    {
        public ConsultaContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Urgencia> Urgencias { get; set; }
        public DbSet<Hospitalizacion> Hospitalizacions { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Odontologia> Odontologias { get; set; }
        public DbSet<Consulta> Consultas { get; set; }
    }
}
