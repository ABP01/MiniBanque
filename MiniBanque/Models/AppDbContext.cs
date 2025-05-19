using Microsoft.EntityFrameworkCore;

namespace MiniBanque.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Compte> Comptes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=.\\SQLEXPRESS;Database=minibanquedb;Trusted_Connection=True; MultipleActiveResultSets=true; TrustServerCertificate=True; Encrypt=True;");
        } 

    }
}
