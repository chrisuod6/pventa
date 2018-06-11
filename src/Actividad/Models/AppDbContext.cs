using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace Actividad.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options): base(options)
        {

        }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<NivelUsuarios> NivelesUsuarios { get; set; }
        public DbSet<SolicitadosItems> SolicitadosItems { get; set; }

    }
}
