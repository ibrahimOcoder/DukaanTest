﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductsAPI.DBContexts;

namespace ProductsAPI.Migrations
{
    [DbContext(typeof(ProductContext))]
    [Migration("20220518190633_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProductsAPI.Model.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Barcode")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("ProductCategoryId")
                        .HasColumnType("int");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.Property<int>("WeightType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasAlternateKey("Barcode")
                        .HasName("SK_Barcode");

                    b.HasIndex("ProductCategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Barcode = "UPC 036725590045",
                            Description = "RZ32M72407F/SG",
                            IsDeleted = false,
                            Name = "RZ32M72407F 1Door with Convertible Mode, Lamb Freeze, 315L",
                            Price = 89000.0,
                            ProductCategoryId = 3,
                            Weight = 78.0,
                            WeightType = 2
                        },
                        new
                        {
                            Id = 2,
                            Barcode = "UPC 036725596543",
                            Description = "RT29K5030S8/ES",
                            IsDeleted = false,
                            Name = "RT29K5030S8/ES Top Freezer with Twin Cooling Plus™, 299L",
                            Price = 119000.0,
                            ProductCategoryId = 3,
                            Weight = 56.0,
                            WeightType = 2
                        },
                        new
                        {
                            Id = 3,
                            Barcode = "UPC 036725593647",
                            Description = "QA55Q60AAUXMM",
                            IsDeleted = false,
                            Name = "Q60A QLED 4K Smart TV",
                            Price = 125000.0,
                            ProductCategoryId = 3,
                            Weight = 36.0,
                            WeightType = 2
                        },
                        new
                        {
                            Id = 4,
                            Barcode = "UPC 036725593019",
                            Description = "UA65AU9000UXMM",
                            IsDeleted = false,
                            Name = "AU9000 Crystal UHD 4K Smart TV",
                            Price = 149000.0,
                            ProductCategoryId = 3,
                            Weight = 48.0,
                            WeightType = 2
                        },
                        new
                        {
                            Id = 5,
                            Barcode = "UPC 036725931648",
                            Description = "Chicken Nuggets",
                            IsDeleted = false,
                            Name = "Sabroso Nuggets",
                            Price = 745.0,
                            ProductCategoryId = 3,
                            Weight = 820.0,
                            WeightType = 1
                        },
                        new
                        {
                            Id = 6,
                            Barcode = "UPC 0367259346258",
                            Description = "Chicken Thighs",
                            IsDeleted = false,
                            Name = "Sufi Boneless Thigh",
                            Price = 392.0,
                            ProductCategoryId = 3,
                            Weight = 500.0,
                            WeightType = 1
                        },
                        new
                        {
                            Id = 7,
                            Barcode = "UPC 0367259956320",
                            Description = "1.5 lt",
                            IsDeleted = false,
                            Name = "Coca Cola",
                            Price = 95.0,
                            ProductCategoryId = 6,
                            Weight = 1.5,
                            WeightType = 3
                        },
                        new
                        {
                            Id = 8,
                            Barcode = "UPC 0367259564720",
                            Description = "500 mt",
                            IsDeleted = false,
                            Name = "Pepsi",
                            Price = 50.0,
                            ProductCategoryId = 6,
                            Weight = 500.0,
                            WeightType = 4
                        });
                });

            modelBuilder.Entity("ProductsAPI.Model.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("ParentCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsDeleted = false,
                            Name = "Electronics",
                            ParentCategoryId = 0
                        },
                        new
                        {
                            Id = 2,
                            IsDeleted = false,
                            Name = "Grocery",
                            ParentCategoryId = 0
                        },
                        new
                        {
                            Id = 3,
                            IsDeleted = false,
                            Name = "Fridges",
                            ParentCategoryId = 1
                        },
                        new
                        {
                            Id = 4,
                            IsDeleted = false,
                            Name = "LED TVs",
                            ParentCategoryId = 1
                        },
                        new
                        {
                            Id = 5,
                            IsDeleted = false,
                            Name = "Frozen Items",
                            ParentCategoryId = 2
                        },
                        new
                        {
                            Id = 6,
                            IsDeleted = false,
                            Name = "Beverages",
                            ParentCategoryId = 2
                        });
                });

            modelBuilder.Entity("ProductsAPI.Model.ProductStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.ToTable("ProductStatus");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Status = "IN_STOCK"
                        },
                        new
                        {
                            Id = 2,
                            Status = "SOLD"
                        },
                        new
                        {
                            Id = 3,
                            Status = "DAMAGED"
                        });
                });

            modelBuilder.Entity("ProductsAPI.Model.ProductStatusDetail", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("ProductStatusId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductStatusId1")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "ProductStatusId");

                    b.HasIndex("ProductStatusId1");

                    b.ToTable("ProductStatusDetail");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            ProductStatusId = 1,
                            Quantity = 10
                        },
                        new
                        {
                            ProductId = 1,
                            ProductStatusId = 3,
                            Quantity = 0
                        },
                        new
                        {
                            ProductId = 1,
                            ProductStatusId = 2,
                            Quantity = 0
                        },
                        new
                        {
                            ProductId = 2,
                            ProductStatusId = 1,
                            Quantity = 10
                        },
                        new
                        {
                            ProductId = 2,
                            ProductStatusId = 3,
                            Quantity = 0
                        },
                        new
                        {
                            ProductId = 2,
                            ProductStatusId = 2,
                            Quantity = 0
                        },
                        new
                        {
                            ProductId = 3,
                            ProductStatusId = 1,
                            Quantity = 10
                        },
                        new
                        {
                            ProductId = 3,
                            ProductStatusId = 3,
                            Quantity = 0
                        },
                        new
                        {
                            ProductId = 3,
                            ProductStatusId = 2,
                            Quantity = 0
                        },
                        new
                        {
                            ProductId = 4,
                            ProductStatusId = 1,
                            Quantity = 10
                        },
                        new
                        {
                            ProductId = 4,
                            ProductStatusId = 3,
                            Quantity = 0
                        },
                        new
                        {
                            ProductId = 4,
                            ProductStatusId = 2,
                            Quantity = 0
                        },
                        new
                        {
                            ProductId = 5,
                            ProductStatusId = 1,
                            Quantity = 10
                        },
                        new
                        {
                            ProductId = 5,
                            ProductStatusId = 3,
                            Quantity = 0
                        },
                        new
                        {
                            ProductId = 5,
                            ProductStatusId = 2,
                            Quantity = 0
                        },
                        new
                        {
                            ProductId = 6,
                            ProductStatusId = 1,
                            Quantity = 10
                        },
                        new
                        {
                            ProductId = 6,
                            ProductStatusId = 3,
                            Quantity = 0
                        },
                        new
                        {
                            ProductId = 6,
                            ProductStatusId = 2,
                            Quantity = 0
                        },
                        new
                        {
                            ProductId = 7,
                            ProductStatusId = 1,
                            Quantity = 10
                        },
                        new
                        {
                            ProductId = 7,
                            ProductStatusId = 3,
                            Quantity = 0
                        },
                        new
                        {
                            ProductId = 7,
                            ProductStatusId = 2,
                            Quantity = 0
                        },
                        new
                        {
                            ProductId = 8,
                            ProductStatusId = 1,
                            Quantity = 10
                        },
                        new
                        {
                            ProductId = 8,
                            ProductStatusId = 3,
                            Quantity = 0
                        },
                        new
                        {
                            ProductId = 8,
                            ProductStatusId = 2,
                            Quantity = 0
                        });
                });

            modelBuilder.Entity("ProductsAPI.Model.Product", b =>
                {
                    b.HasOne("ProductsAPI.Model.ProductCategory", null)
                        .WithMany("Products")
                        .HasForeignKey("ProductCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProductsAPI.Model.ProductStatusDetail", b =>
                {
                    b.HasOne("ProductsAPI.Model.Product", null)
                        .WithMany("ProductStatusDetail")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProductsAPI.Model.ProductStatus", null)
                        .WithMany("ProductStatusDetail")
                        .HasForeignKey("ProductStatusId1");
                });

            modelBuilder.Entity("ProductsAPI.Model.Product", b =>
                {
                    b.Navigation("ProductStatusDetail");
                });

            modelBuilder.Entity("ProductsAPI.Model.ProductCategory", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("ProductsAPI.Model.ProductStatus", b =>
                {
                    b.Navigation("ProductStatusDetail");
                });
#pragma warning restore 612, 618
        }
    }
}
