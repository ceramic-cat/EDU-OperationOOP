using Microsoft.EntityFrameworkCore;
namespace OperationOOP.Api;

public class PurchasableProductContext : DbContext
{
    public PurchasableProductContext(DbContextOptions<PurchasableProductContext> options) : base(options) { }
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
