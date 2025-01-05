using Microsoft.EntityFrameworkCore;

public class BakeryContext : DbContext
{
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<SupplierProduct> SupplierProducts { get; set; }

    public BakeryContext(DbContextOptions<BakeryContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SupplierProduct>()
            .HasKey(sp => new { sp.SupplierId, sp.ProductId });

        modelBuilder.Entity<SupplierProduct>()
            .HasOne(sp => sp.Supplier)
            .WithMany(s => s.SupplierProducts)
            .HasForeignKey(sp => sp.SupplierId);

        modelBuilder.Entity<SupplierProduct>()
            .HasOne(sp => sp.Product)
            .WithMany(p => p.SupplierProducts)
            .HasForeignKey(sp => sp.ProductId);

        modelBuilder.Entity<Supplier>().HasData(
            new Supplier { SupplierId = 1, Name = "Bageri liten", Address = "Gata 1", ContactPerson = "Lilja", PhoneNumber = "0701234567", Email = "lilja@gross.se" },
            new Supplier { SupplierId = 2, Name = "Matleverantör AB", Address = "Gata 2", ContactPerson = "Dalija", PhoneNumber = "0707654321", Email = "dalija@mat.se" }
        );

        modelBuilder.Entity<Product>().HasData(
            new Product { ProductId = 1, Name = "Mjöl", ArticleNumber = "1001" },
            new Product { ProductId = 2, Name = "Socker", ArticleNumber = "1002" }
        );

        modelBuilder.Entity<SupplierProduct>().HasData(
            new SupplierProduct { SupplierId = 1, ProductId = 1, PricePerKg = 15.50m },
            new SupplierProduct { SupplierId = 2, ProductId = 1, PricePerKg = 14.00m },
            new SupplierProduct { SupplierId = 1, ProductId = 2, PricePerKg = 10.00m }
        );
    }
}
