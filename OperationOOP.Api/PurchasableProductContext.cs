using Microsoft.EntityFrameworkCore;
namespace OperationOOP.Api;

public class ProductContext : DbContext
{
    public ProductContext(DbContextOptions<ProductContext> options) : base(options) { }
    public DbSet<PurchasableProduct> PurchasableProducts { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PurchasableProduct>()
            .HasDiscriminator<string>("ProductType") // Discriminator column
            .HasValue<Keyboard>("Keyboard")
            .HasValue<Mouse>("Mouse")
            .HasValue<Mousepad>("Mousepad");

    }

}
