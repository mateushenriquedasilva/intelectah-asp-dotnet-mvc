using Intelectah.Models;
using Microsoft.EntityFrameworkCore;

namespace Intelectah.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<TiposDeExame> TiposDeExame { get; set; }

        // configuração do banco de dados com EF
        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite(connectionString: "DataSource=intelectah.db;Cache=Shared");
    }
}