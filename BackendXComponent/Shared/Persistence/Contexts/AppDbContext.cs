
using BackendXComponent.ComponentX.Domain.Models;
using BackendXComponent.Shared.Extensions;
//Agregamos el Microsoft.EntityFrameworkCore para poder usar el DbContext
using Microsoft.EntityFrameworkCore;

namespace BackendXComponent.Shared.Persistence.Contexts;

//

public class AppDbContext:DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<SubProduct> SubProducts { get; set; }
    
    
    //Agregamos el constructor
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    
    //Agregamos el metodo OnModelCreating
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Product>().ToTable("Products");
        builder.Entity<Product>().HasKey(p => p.Id);
        builder.Entity<Product>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(300);
        builder.Entity<Product>().Property(p => p.Description).IsRequired().HasMaxLength(800);
        builder.Entity<Product>().Property(p => p.Image).IsRequired().HasMaxLength(800);
        builder.Entity<Product>().Property(p => p.Price).IsRequired();
        builder.Entity<Product>().Property(p => p.SpecificDetails).IsRequired().HasMaxLength(1000);
        builder.Entity<Product>().Property(p => p.GeneralDetails).IsRequired().HasMaxLength(1000);
        
        //Relationships
        builder.Entity<Product>()
            .HasMany(p => p.SubProductsList)
            .WithOne(p => p.Product)
            .HasForeignKey(p => p.ProductId);
        
        builder.Entity<SubProduct>().ToTable("Subproducts");
        builder.Entity<SubProduct>().HasKey(p => p.Id);
        builder.Entity<SubProduct>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<SubProduct>().Property(p => p.Name).IsRequired().HasMaxLength(500);
        builder.Entity<SubProduct>().Property(p => p.Specification).IsRequired().HasMaxLength(800);
        builder.Entity<SubProduct>().Property(p => p.Price).IsRequired();
        builder.Entity<SubProduct>().Property(p => p.Image).IsRequired().HasMaxLength(800);
        //Apply the snake case naming convention
        builder.UseSnakeCaseNamingConvention();
    }
    
}