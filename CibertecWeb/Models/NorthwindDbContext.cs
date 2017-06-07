using Microsoft.EntityFrameworkCore;

namespace CibertecWeb.Models
{
    public class NorthwindDbContext : DbContext //hereda de EF
    {
        //El contructor
        public NorthwindDbContext(DbContextOptions<NorthwindDbContext> options): base(options)
        {
            // options es para configurar EF
        }

        //Dbset son la tablas para EF
        public DbSet<customer> Customers { get; set; }
        public DbSet<supplier> Suppliers { get; set; }
        public DbSet<product> Products { get; set; }

        //OnModelCreating: cuando se cree el modelo lo sobre escribimos(override)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<customer>().ToTable("Customer");
            modelBuilder.Entity<supplier>().ToTable("Supplier");
            modelBuilder.Entity<product>().ToTable("Product");
        }

    }
}
