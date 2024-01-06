using KlumperBank.Data.Mappings;
using KlumperBank.Models;
using Microsoft.EntityFrameworkCore;

namespace KlumperBank.Data
{
    public class KlumperBankDtContext : DbContext
    {
        readonly IConfiguration _configuration;
        public KlumperBankDtContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            =>modelBuilder.ApplyConfiguration(new UserMap());
        
    }
}
