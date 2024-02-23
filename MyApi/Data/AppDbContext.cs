using System;
using Microsoft.EntityFrameworkCore;
using MyLibrary.Models;

namespace MyApi.Data;
{
    public class AppDbContext : DbContext
{
    // DbSet properties for application data
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    public DbSet<Order> Orders { get; set; }

    // Override OnModelCreating to configure relationships, if needed
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        optionsBuilder.UseSqlServer("your_connection_string_here"); // Example of configuring a connection string
                                                                    // Configure relationships, if needed
        modelBuilder.Entity<Product>()
            .HasOne(p => p.Category)
            .WithMany()
            .HasForeignKey(p => p.CategoryId)
            .IsRequired(false); // Example of configuring a relationship between Product and Category
    }
}
}