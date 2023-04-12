using AppProduto.Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace AppProduto.Infra.Data;

public class ApplicationDbContext: DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {

        builder.Entity<Product>()
           .Property(p => p.Name).IsRequired();
        builder.Entity<Product>()
            .Property(p => p.Description).HasMaxLength(255);   

        builder.Entity<Category>()
            .Property(c => c.Name).IsRequired();

        /*base.OnModelCreating(builder);

        builder.Ignore<Notification>();

        builder.Entity<Product>()
            .Property(p => p.Name).IsRequired();
        builder.Entity<Product>()
            .Property(p => p.Description).HasMaxLength(255);
        builder.Entity<Product>()
            .Property(p => p.Price).HasColumnType("decimal(10,2)").IsRequired();

        builder.Entity<Category>()
            .Property(c => c.Name).IsRequired();

        builder.Entity<Order>()
            .Property(o => o.ClientId).IsRequired();
        builder.Entity<Order>()
            .Property(o => o.DeliveryAddress).IsRequired();
        builder.Entity<Order>()
            .HasMany(o => o.Products)
            .WithMany(p => p.Orders)
            .UsingEntity(x => x.ToTable("OrderProducts"));*/
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configuration)
    {
        configuration.Properties<string>()
            .HaveMaxLength(100);
    }
}