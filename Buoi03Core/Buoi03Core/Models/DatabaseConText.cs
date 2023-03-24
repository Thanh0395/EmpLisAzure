using Microsoft.EntityFrameworkCore;

namespace Buoi03Core.Models
{
    public class DatabaseConText:DbContext
    {
        public DatabaseConText(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>().HasKey(e => e.Id);
        }
        public DbSet<Employee> Employees { get; set; }

    }
}
