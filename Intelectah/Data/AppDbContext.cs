using Intelectah.Models;
using Microsoft.EntityFrameworkCore;

namespace Intelectah.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Paciente> Pacientes { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite(connectionString: "DataSource=intelectah.db;Cache=Shared");
    }
}