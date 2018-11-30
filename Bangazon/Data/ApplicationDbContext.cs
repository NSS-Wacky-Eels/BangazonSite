using System;
using System.Collections.Generic;
using System.Text;
using Bangazon.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bangazon.Data {
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser> {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base (options) { }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductType> ProductType { get; set; }
        public DbSet<PaymentType> PaymentType { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderProduct> OrderProduct { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder) {
            base.OnModelCreating (modelBuilder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            modelBuilder.Entity<Order> ()
                .Property (b => b.DateCreated)
                .HasDefaultValueSql ("GETDATE()");

            // Restrict deletion of related order when OrderProducts entry is removed
            modelBuilder.Entity<Order> ()
                .HasMany (o => o.OrderProducts)
                .WithOne (l => l.Order)
                .OnDelete (DeleteBehavior.Restrict);

            modelBuilder.Entity<Product> ()
                .Property (b => b.DateCreated)
                .HasDefaultValueSql ("GETDATE()");

            // Restrict deletion of related product when OrderProducts entry is removed
            modelBuilder.Entity<Product> ()
                .HasMany (o => o.OrderProducts)
                .WithOne (l => l.Product)
                .OnDelete (DeleteBehavior.Restrict);

            modelBuilder.Entity<PaymentType> ()
                .Property (b => b.DateCreated)
                .HasDefaultValueSql ("GETDATE()");

            ApplicationUser user = new ApplicationUser {
                FirstName = "admin",
                LastName = "admin",
                StreetAddress = "123 Infinity Way",
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid ().ToString ("D")
            };
            var passwordHash = new PasswordHasher<ApplicationUser> ();
            user.PasswordHash = passwordHash.HashPassword (user, "Admin8*");
            modelBuilder.Entity<ApplicationUser> ().HasData (user);

            ApplicationUser user2 = new ApplicationUser
            {
                FirstName = "alejandro",
                LastName = "alejandro",
                StreetAddress = "123 Infinity Way",
                UserName = "alejandro@alejandro.com",
                NormalizedUserName = "alejandro@alejandro.COM",
                Email = "alejandro@alejandro.com",
                NormalizedEmail = "alejandro@alejandro.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };
            var passwordHash2 = new PasswordHasher<ApplicationUser>();
            user2.PasswordHash = passwordHash2.HashPassword(user2, "Alex2*");
            modelBuilder.Entity<ApplicationUser>().HasData(user2);

            modelBuilder.Entity<PaymentType> ().HasData (
                new PaymentType () {
                    PaymentTypeId = 1,
                        UserId = user.Id,
                        Description = "American Express",
                        AccountNumber = "86753095551212"
                },
                new PaymentType () {
                    PaymentTypeId = 2,
                        UserId = user.Id,
                        Description = "Discover",
                        AccountNumber = "4102948572991"
                },
                new PaymentType()
                {
                    PaymentTypeId = 3,
                    UserId = user2.Id,
                    Description = "Discover",
                    AccountNumber = "1826475983857"
                },
                new PaymentType()
                {
                    PaymentTypeId = 4,
                    UserId = user2.Id,
                    Description = "American Express",
                    AccountNumber = "2345123467895"
                }
            );

            modelBuilder.Entity<ProductType> ().HasData (
                new ProductType () {
                    ProductTypeId = 1,
                        Label = "Sporting Goods"
                },
                new ProductType () {
                    ProductTypeId = 2,
                        Label = "Appliances"
                }
            );

            modelBuilder.Entity<Product> ().HasData (
                new Product () {
                    ProductId = 1,
                        ProductTypeId = 1,
                        UserId = user.Id,
                        Description = "It flies high",
                        Title = "Kite",
                        Quantity = 100,
                        Price = 2.99
                },
                new Product () {
                    ProductId = 2,
                        ProductTypeId = 2,
                        UserId = user.Id,
                        Description = "It rolls fast",
                        Title = "Wheelbarrow",
                        Quantity = 5,
                        Price = 29.99
                },
                new Product()
                {
                    ProductId = 3,
                    ProductTypeId = 2,
                    UserId = user2.Id,
                    Description = "They're short",
                    Title = "High-waters",
                    Quantity = 5,
                    Price = 29.99
                },
                new Product()
                {
                    ProductId = 4,
                    ProductTypeId = 2,
                    UserId = user2.Id,
                    Description = "It cleans stuff",
                    Title = "Washer",
                    Quantity = 5,
                    Price = 429.99
                },
                new Product()
                {
                    ProductId = 5,
                    ProductTypeId = 2,
                    UserId = user2.Id,
                    Description = "It drys stuff",
                    Title = "Dryer",
                    Quantity = 5,
                    Price = 329.99
                },
                new Product()
                {
                    ProductId = 6,
                    ProductTypeId = 2,
                    UserId = user.Id,
                    Description = "It mixes stuff",
                    Title = "Mixer",
                    Quantity = 5,
                    Price = 129.99
                },
                new Product()
                {
                    ProductId = 7,
                    ProductTypeId = 2,
                    UserId = user.Id,
                    Description = "Makes Bread",
                    Title = "Bread maker",
                    Quantity = 8,
                    Price = 29.99
                },
                new Product()
                {
                    ProductId = 8,
                    ProductTypeId = 2,
                    UserId = user2.Id,
                    Description = "Makes Rice",
                    Title = "Rice maker",
                    Quantity = 90,
                    Price = 19.99
                },
                new Product()
                {
                    ProductId = 9,
                    ProductTypeId = 2,
                    UserId = user2.Id,
                    Description = "Makes stuff cold",
                    Title = "Freezer",
                    Quantity = 190,
                    Price = 59.99
                },
                new Product()
                {
                    ProductId = 10,
                    ProductTypeId = 2,
                    UserId = user.Id,
                    Description = "Cooks stuff",
                    Title = "Stove",
                    Quantity = 10,
                    Price = 259.99
                },
                new Product()
                {
                    ProductId = 11,
                    ProductTypeId = 1,
                    UserId = user.Id,
                    Description = "It bounces high",
                    Title = "Ball",
                    Quantity = 130,
                    Price = 9.99
                }, 
                new Product()
                {
                    ProductId = 12,
                    ProductTypeId = 1,
                    UserId = user.Id,
                    Description = "It's Fast",
                    Title = "Foot Ball",
                    Quantity = 30,
                    Price = 9.99
                },
                new Product()
                {
                    ProductId = 13,
                    ProductTypeId = 1,
                    UserId = user2.Id,
                    Description = "Keeps you dry",
                    Title = "Tent",
                    Quantity = 5630,
                    Price = 89.99
                },
                new Product()
                {
                    ProductId = 14,
                    ProductTypeId = 1,
                    UserId = user2.Id,
                    Description = "Keeps you Warm",
                    Title = "Sleeping Bag",
                    Quantity = 40,
                    Price = 39.99
                },
                new Product()
                {
                    ProductId = 15,
                    ProductTypeId = 1,
                    UserId = user.Id,
                    Description = "Soooo cozy",
                    Title = "Running Shoes",
                    Quantity = 560,
                    Price = 99.99
                },
                new Product()
                {
                    ProductId = 16,
                    ProductTypeId = 1,
                    UserId = user.Id,
                    Description = "Its soo fast",
                    Title = "Frizbee",
                    Quantity = 5,
                    Price = 7.99
                },
                new Product()
                {
                    ProductId = 17,
                    ProductTypeId = 1,
                    UserId = user.Id,
                    Description = "Makes you look like you work in an office",
                    Title = "Golf Club",
                    Quantity = 5,
                    Price = 72.99
                },
                new Product()
                {
                    ProductId = 18,
                    ProductTypeId = 1,
                    UserId = user.Id,
                    Description = "Makes you look like you work in an office",
                    Title = "Golf Ball",
                    Quantity = 54567,
                    Price = 2.99
                },
                new Product()
                {
                    ProductId = 19,
                    ProductTypeId = 1,
                    UserId = user2.Id,
                    Description = "They are REALLY SHORT",
                    Title = "Sport Shorts",
                    Quantity = 67,
                    Price = 22.99
                },
                new Product()
                {
                    ProductId = 20,
                    ProductTypeId = 1,
                    UserId = user.Id,
                    Description = "Keeps you cool",
                    Title = "Sport Shirt",
                    Quantity = 167,
                    Price = 18.99
                },
                new Product()
                {
                    ProductId = 21,
                    ProductTypeId = 1,
                    UserId = user.Id,
                    Description = "keeps the sweat out of your eyes",
                    Title = "Sweat Band",
                    Quantity = 167,
                    Price = 8.99
                }
            );

            modelBuilder.Entity<Order> ().HasData (
                new Order () {
                    OrderId = 1,
                    UserId = user.Id,
                    PaymentTypeId = null
                },
                new Order()
                {
                    OrderId = 2,
                    UserId = user2.Id,
                    PaymentTypeId = null
                }
            );

            modelBuilder.Entity<OrderProduct> ().HasData (
                new OrderProduct () {
                    OrderProductId = 1,
                    OrderId = 1,
                    ProductId = 1
                }
            );

            modelBuilder.Entity<OrderProduct> ().HasData (
                new OrderProduct () {
                    OrderProductId = 2,
                    OrderId = 1,
                    ProductId = 2
                }
            );

            modelBuilder.Entity<OrderProduct>().HasData(
                new OrderProduct()
                {
                    OrderProductId = 3,
                    OrderId = 2,
                    ProductId = 3
                }
            );

            modelBuilder.Entity<OrderProduct>().HasData(
                new OrderProduct()
                {
                    OrderProductId = 4,
                    OrderId = 2,
                    ProductId = 2
                }
            );

        }
    }
}