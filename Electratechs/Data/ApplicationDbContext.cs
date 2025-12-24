using Microsoft.EntityFrameworkCore;
using Electratechs.Models; // تأكد من استدعاء مسار الموديلات الخاص بك

namespace Electratechs.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

      
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Accessory> Accessories { get; set; }
        public DbSet<ProductAccessory> ProductAccessories { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           
            modelBuilder.Entity<ProductAccessory>()
                .HasKey(pa => new { pa.ProductId, pa.AccessoryId }); 

            modelBuilder.Entity<ProductAccessory>()
                .HasOne(pa => pa.Product)
                .WithMany(p => p.ProductAccessories)
                .HasForeignKey(pa => pa.ProductId);

            modelBuilder.Entity<ProductAccessory>()
                .HasOne(pa => pa.Accessory)
                .WithMany(a => a.ProductAccessories)
                .HasForeignKey(pa => pa.AccessoryId);
        }
    }
}