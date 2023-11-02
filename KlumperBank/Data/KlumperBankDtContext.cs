using KlumperBank.Data.Mappings;
using KlumperBank.Models;
using Microsoft.EntityFrameworkCore;

namespace KlumperBank.Data
{
    public class KlumperBankDtContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Server=localhost,1433;Database=KlumperBank;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=true");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            =>modelBuilder.ApplyConfiguration(new UserMap());
        
    }
}
