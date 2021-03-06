﻿// <auto-generated />
using System;
using Bangazon.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Bangazon.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20181130175924_InitialSetup")]
    partial class InitialSetup
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Bangazon.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<string>("StreetAddress")
                        .IsRequired();

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new { Id = "9b562b5e-1cc0-4073-abdb-d81b9d93129f", AccessFailedCount = 0, ConcurrencyStamp = "3ce49cbd-b1a6-4139-91c5-d0d631c68eda", Email = "admin@admin.com", EmailConfirmed = true, FirstName = "admin", LastName = "admin", LockoutEnabled = false, NormalizedEmail = "ADMIN@ADMIN.COM", NormalizedUserName = "ADMIN@ADMIN.COM", PasswordHash = "AQAAAAEAACcQAAAAEE4JW1U66vVRgsRFwPIallUa0uyJbskOqRckzNvpuLDcm1jIpHBuLyAtD7ZW352wSA==", PhoneNumberConfirmed = false, SecurityStamp = "b7386f3f-5056-4dd1-9ca1-47d903ba2911", StreetAddress = "123 Infinity Way", TwoFactorEnabled = false, UserName = "admin@admin.com" },
                        new { Id = "a12bfacf-2e68-43ed-8e7a-689f45e616a2", AccessFailedCount = 0, ConcurrencyStamp = "81e868bc-1a63-4875-bf45-6e3af3e50b4f", Email = "alejandro@alejandro.com", EmailConfirmed = true, FirstName = "alejandro", LastName = "alejandro", LockoutEnabled = false, NormalizedEmail = "alejandro@alejandro.COM", NormalizedUserName = "alejandro@alejandro.COM", PasswordHash = "AQAAAAEAACcQAAAAEBdHLP+6g5uCZeL+Cx4gPeaK5R3Z1+sge+I3JlqSbTLopt5WaJERTvlfoCw/vlBfWg==", PhoneNumberConfirmed = false, SecurityStamp = "d31f6dc3-840c-435f-8360-4633b02b2603", StreetAddress = "123 Infinity Way", TwoFactorEnabled = false, UserName = "alejandro@alejandro.com" }
                    );
                });

            modelBuilder.Entity("Bangazon.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DateCompleted");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int?>("PaymentTypeId");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("OrderId");

                    b.HasIndex("PaymentTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("Order");

                    b.HasData(
                        new { OrderId = 1, DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), UserId = "9b562b5e-1cc0-4073-abdb-d81b9d93129f" },
                        new { OrderId = 2, DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), UserId = "a12bfacf-2e68-43ed-8e7a-689f45e616a2" }
                    );
                });

            modelBuilder.Entity("Bangazon.Models.OrderProduct", b =>
                {
                    b.Property<int>("OrderProductId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OrderId");

                    b.Property<int>("ProductId");

                    b.HasKey("OrderProductId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderProduct");

                    b.HasData(
                        new { OrderProductId = 1, OrderId = 1, ProductId = 1 },
                        new { OrderProductId = 2, OrderId = 1, ProductId = 2 },
                        new { OrderProductId = 3, OrderId = 2, ProductId = 3 },
                        new { OrderProductId = 4, OrderId = 2, ProductId = 2 }
                    );
                });

            modelBuilder.Entity("Bangazon.Models.PaymentType", b =>
                {
                    b.Property<int>("PaymentTypeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountNumber")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(55);

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("PaymentTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("PaymentType");

                    b.HasData(
                        new { PaymentTypeId = 1, AccountNumber = "86753095551212", DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Description = "American Express", UserId = "9b562b5e-1cc0-4073-abdb-d81b9d93129f" },
                        new { PaymentTypeId = 2, AccountNumber = "4102948572991", DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Description = "Discover", UserId = "9b562b5e-1cc0-4073-abdb-d81b9d93129f" },
                        new { PaymentTypeId = 3, AccountNumber = "1826475983857", DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Description = "Discover", UserId = "a12bfacf-2e68-43ed-8e7a-689f45e616a2" },
                        new { PaymentTypeId = 4, AccountNumber = "2345123467895", DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Description = "American Express", UserId = "a12bfacf-2e68-43ed-8e7a-689f45e616a2" }
                    );
                });

            modelBuilder.Entity("Bangazon.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("ImagePath");

                    b.Property<double>("Price");

                    b.Property<int>("ProductTypeId");

                    b.Property<int>("Quantity");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(55);

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("ProductId");

                    b.HasIndex("ProductTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("Product");

                    b.HasData(
                        new { ProductId = 1, DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Description = "It flies high", Price = 2.99, ProductTypeId = 1, Quantity = 100, Title = "Kite", UserId = "9b562b5e-1cc0-4073-abdb-d81b9d93129f" },
                        new { ProductId = 2, DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Description = "It rolls fast", Price = 29.99, ProductTypeId = 2, Quantity = 5, Title = "Wheelbarrow", UserId = "9b562b5e-1cc0-4073-abdb-d81b9d93129f" },
                        new { ProductId = 3, DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Description = "They're short", Price = 29.99, ProductTypeId = 2, Quantity = 5, Title = "High-waters", UserId = "a12bfacf-2e68-43ed-8e7a-689f45e616a2" },
                        new { ProductId = 4, DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Description = "It cleans stuff", Price = 429.99, ProductTypeId = 2, Quantity = 5, Title = "Washer", UserId = "a12bfacf-2e68-43ed-8e7a-689f45e616a2" },
                        new { ProductId = 5, DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Description = "It drys stuff", Price = 329.99, ProductTypeId = 2, Quantity = 5, Title = "Dryer", UserId = "a12bfacf-2e68-43ed-8e7a-689f45e616a2" },
                        new { ProductId = 6, DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Description = "It mixes stuff", Price = 129.99, ProductTypeId = 2, Quantity = 5, Title = "Mixer", UserId = "9b562b5e-1cc0-4073-abdb-d81b9d93129f" },
                        new { ProductId = 7, DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Description = "Makes Bread", Price = 29.99, ProductTypeId = 2, Quantity = 8, Title = "Bread maker", UserId = "9b562b5e-1cc0-4073-abdb-d81b9d93129f" },
                        new { ProductId = 8, DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Description = "Makes Rice", Price = 19.99, ProductTypeId = 2, Quantity = 90, Title = "Rice maker", UserId = "a12bfacf-2e68-43ed-8e7a-689f45e616a2" },
                        new { ProductId = 9, DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Description = "Makes stuff cold", Price = 59.99, ProductTypeId = 2, Quantity = 190, Title = "Freezer", UserId = "a12bfacf-2e68-43ed-8e7a-689f45e616a2" },
                        new { ProductId = 10, DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Description = "Cooks stuff", Price = 259.99, ProductTypeId = 2, Quantity = 10, Title = "Stove", UserId = "9b562b5e-1cc0-4073-abdb-d81b9d93129f" },
                        new { ProductId = 11, DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Description = "It bounces high", Price = 9.99, ProductTypeId = 1, Quantity = 130, Title = "Ball", UserId = "9b562b5e-1cc0-4073-abdb-d81b9d93129f" },
                        new { ProductId = 12, DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Description = "It's Fast", Price = 9.99, ProductTypeId = 1, Quantity = 30, Title = "Foot Ball", UserId = "9b562b5e-1cc0-4073-abdb-d81b9d93129f" },
                        new { ProductId = 13, DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Description = "Keeps you dry", Price = 89.99, ProductTypeId = 1, Quantity = 5630, Title = "Tent", UserId = "a12bfacf-2e68-43ed-8e7a-689f45e616a2" },
                        new { ProductId = 14, DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Description = "Keeps you Warm", Price = 39.99, ProductTypeId = 1, Quantity = 40, Title = "Sleeping Bag", UserId = "a12bfacf-2e68-43ed-8e7a-689f45e616a2" },
                        new { ProductId = 15, DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Description = "Soooo cozy", Price = 99.99, ProductTypeId = 1, Quantity = 560, Title = "Running Shoes", UserId = "9b562b5e-1cc0-4073-abdb-d81b9d93129f" },
                        new { ProductId = 16, DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Description = "Its soo fast", Price = 7.99, ProductTypeId = 1, Quantity = 5, Title = "Frizbee", UserId = "9b562b5e-1cc0-4073-abdb-d81b9d93129f" },
                        new { ProductId = 17, DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Description = "Makes you look like you work in an office", Price = 72.99, ProductTypeId = 1, Quantity = 5, Title = "Golf Club", UserId = "9b562b5e-1cc0-4073-abdb-d81b9d93129f" },
                        new { ProductId = 18, DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Description = "Makes you look like you work in an office", Price = 2.99, ProductTypeId = 1, Quantity = 54567, Title = "Golf Ball", UserId = "9b562b5e-1cc0-4073-abdb-d81b9d93129f" },
                        new { ProductId = 19, DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Description = "They are REALLY SHORT", Price = 22.99, ProductTypeId = 1, Quantity = 67, Title = "Sport Shorts", UserId = "a12bfacf-2e68-43ed-8e7a-689f45e616a2" },
                        new { ProductId = 20, DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Description = "Keeps you cool", Price = 18.99, ProductTypeId = 1, Quantity = 167, Title = "Sport Shirt", UserId = "9b562b5e-1cc0-4073-abdb-d81b9d93129f" },
                        new { ProductId = 21, DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Description = "keeps the sweat out of your eyes", Price = 8.99, ProductTypeId = 1, Quantity = 167, Title = "Sweat Band", UserId = "9b562b5e-1cc0-4073-abdb-d81b9d93129f" }
                    );
                });

            modelBuilder.Entity("Bangazon.Models.ProductType", b =>
                {
                    b.Property<int>("ProductTypeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("ProductTypeId");

                    b.ToTable("ProductType");

                    b.HasData(
                        new { ProductTypeId = 1, Label = "Sporting Goods" },
                        new { ProductTypeId = 2, Label = "Appliances" }
                    );
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Bangazon.Models.Order", b =>
                {
                    b.HasOne("Bangazon.Models.PaymentType", "PaymentType")
                        .WithMany("Orders")
                        .HasForeignKey("PaymentTypeId");

                    b.HasOne("Bangazon.Models.ApplicationUser", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Bangazon.Models.OrderProduct", b =>
                {
                    b.HasOne("Bangazon.Models.Order", "Order")
                        .WithMany("OrderProducts")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Bangazon.Models.Product", "Product")
                        .WithMany("OrderProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Bangazon.Models.PaymentType", b =>
                {
                    b.HasOne("Bangazon.Models.ApplicationUser", "User")
                        .WithMany("PaymentTypes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Bangazon.Models.Product", b =>
                {
                    b.HasOne("Bangazon.Models.ProductType", "ProductType")
                        .WithMany("Products")
                        .HasForeignKey("ProductTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Bangazon.Models.ApplicationUser", "User")
                        .WithMany("Products")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Bangazon.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Bangazon.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Bangazon.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Bangazon.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
