using Microsoft.EntityFrameworkCore;

namespace Cibertec.Models
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
        public DbSet<order> Orders { get; set; }
        public DbSet<orderItem> OrderItems { get; set; }

        //OnModelCreating: cuando se cree el modelo lo sobre escribimos(override)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<customer>().ToTable("Customer");
            modelBuilder.Entity<supplier>().ToTable("Supplier");
            modelBuilder.Entity<product>().ToTable("Product");
            modelBuilder.Entity<order>().ToTable("Order");
            modelBuilder.Entity<orderItem>().ToTable("OrderItem");
        }

    }
}
