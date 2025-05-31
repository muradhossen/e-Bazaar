using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Linq;

namespace Infrastructure.Persistances;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
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


        var dateTimeConverter = new ValueConverter<DateTime, DateTime>(
          v => v.Kind == DateTimeKind.Utc ? v : v.ToUniversalTime(), // Convert to UTC on save
          v => DateTime.SpecifyKind(v, DateTimeKind.Utc)             // Set Kind to UTC on read
      );

        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            foreach (var property in entityType.GetProperties()
                .Where(p => p.ClrType == typeof(DateTime)))
            {
                property.SetValueConverter(dateTimeConverter);
            }
        }
    }

} 
