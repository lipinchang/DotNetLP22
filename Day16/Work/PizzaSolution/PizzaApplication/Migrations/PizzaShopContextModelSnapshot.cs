﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PizzaApplication.Models;

#nullable disable

namespace PizzaApplication.Migrations
{
    [DbContext(typeof(PizzaShopContext))]
    partial class PizzaShopContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PizzaApplication.Models.Customer", b =>
                {
                    b.Property<int>("Phone")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Phone"), 1L, 1);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Phone");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("PizzaApplication.Models.Pizza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsVeg")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Pizzas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Details = "This Homemade Pepperoni Pizza has everything you want—a great crust, gooey cheese, ",
                            IsVeg = true,
                            Name = "ABC",
                            Pic = "/images/Pizza1.jpg",
                            Price = 12.4
                        },
                        new
                        {
                            Id = 2,
                            Details = "This Homemade Pepperoni Pizza has everything you want—a great crust, gooey cheese, ",
                            IsVeg = false,
                            Name = "BBB",
                            Pic = "/images/Pizza2.jpg",
                            Price = 45.700000000000003
                        });
                });
#pragma warning restore 612, 618
        }
    }
}