using Microsoft.EntityFrameworkCore;

namespace Tindorium.Data
{
    public class TindoriumDbContext : DbContext
    {
        
        public DbSet<User> Users { get; set; }
        public TindoriumDbContext()
        {
            base.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=madatabase.db;");
        }
    }
}
