namespace PetrofMusicStore.Data
{
    using Microsoft.EntityFrameworkCore;
    using PetrofMusicStore.Models;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    ProductType = "Saxophone",
                    ProductBrand = "Yamaha"
                },
                 new Product
                 {
                     Id = 2,
                     ProductType = "Violin",
                     ProductBrand = "Stradivarius"
                 },
                  new Product
                  {
                      Id = 3,
                      ProductType = "Accordion",
                      ProductBrand = "Weltmeister"
                  }
                );
        }
    }
}