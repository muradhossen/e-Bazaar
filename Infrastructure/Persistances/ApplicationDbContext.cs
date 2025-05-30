using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistances;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
 
     public DbSet<Product> Products { get; set; }
    public DbSet<Discount> Discounts  { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Discount>()
       .HasOne(d => d.Product)
       .WithOne(p => p.Discount)   
       .HasForeignKey<Discount>(d => d.ProductId)
       .OnDelete(DeleteBehavior.Cascade);  
    }

} 
