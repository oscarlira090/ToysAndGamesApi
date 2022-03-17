﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StockManagementPersistence;

#nullable disable

namespace ToysAndGamesPersistence.Migrations
{
    [DbContext(typeof(ToysAndGamesDbContext))]
    partial class ToysAndGamesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("StockManagementEntities.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AgeRestriction")
                        .HasColumnType("int");

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AgeRestriction = 4,
                            Company = "Marvel",
                            Description = "Iron Man Mega Power",
                            Name = "Iron Man",
                            Price = 100m
                        },
                        new
                        {
                            Id = 2,
                            AgeRestriction = 4,
                            Company = "DC",
                            Description = "BatMan Luxury BatCar",
                            Name = "BatMan",
                            Price = 100m
                        },
                        new
                        {
                            Id = 3,
                            AgeRestriction = 4,
                            Company = "Marvel",
                            Description = "all caracters",
                            Name = "Kit Avengers",
                            Price = 500m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
