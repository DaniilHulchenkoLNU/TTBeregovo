using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TTBeregovo.Models.Entity;

namespace TTBeregovo.DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PurchaseItem> PurchaseItems { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = 1,
                    FullName = "John Doe",
                    BirthDate = new DateTime(1990, 5, 15),
                    RegistrationDate = new DateTime(2023, 1, 1) 
                },
                new Customer
                {
                    Id = 2,
                    FullName = "Jane Smith",
                    BirthDate = new DateTime(1985, 10, 20),
                    RegistrationDate = new DateTime(2024, 1, 1) 
                }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Laptop",
                    Category = "Electronics",
                    SKU = "LAP123",
                    Price = 1500m
                },
                new Product
                {
                    Id = 2,
                    Name = "Smartphone",
                    Category = "Electronics",
                    SKU = "SM123",
                    Price = 800m
                },
                new Product
                {
                    Id = 3,
                    Name = "Desk Chair",
                    Category = "Furniture",
                    SKU = "FURN123",
                    Price = 200m
                }
            );

            modelBuilder.Entity<Purchase>().HasData(
                new Purchase
                {
                    Id = 1,
                    Number = "PURCH001",
                    Date = new DateTime(2024, 1, 20),
                    TotalPrice = 2300m,
                    CustomerId = 1
                },
                new Purchase
                {
                    Id = 2,
                    Number = "PURCH002",
                    Date = new DateTime(2024, 1, 22),
                    TotalPrice = 800m,
                    CustomerId = 2
                }
            );

            modelBuilder.Entity<PurchaseItem>().HasData(
                new PurchaseItem
                {
                    Id = 1,
                    PurchaseId = 1,
                    ProductId = 1,
                    Quantity = 1
                },
                new PurchaseItem
                {
                    Id = 2,
                    PurchaseId = 1,
                    ProductId = 3,
                    Quantity = 2
                },
                new PurchaseItem
                {
                    Id = 3,
                    PurchaseId = 2,
                    ProductId = 2,
                    Quantity = 1
                }
            );
        }

    }
}
