using Microsoft.EntityFrameworkCore;

namespace Test3
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; } // по конвенции название таблицы будет Orders

        public DbSet<Product> Products { get; set; } // по конвенции название таблицы будет Products

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(
                    @"Server=(localdb)\mssqllocaldb;Database=Test3;Trusted_Connection=True;")
                .EnableDetailedErrors()
                .EnableSensitiveDataLogging();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
