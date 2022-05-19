using Microsoft.EntityFrameworkCore;
using ProductsAPI.Model;
using ProductsAPI.Model.Entity;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ProductsAPI.DBContexts
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> Categories { get; set; }
        public DbSet<ProductStatus> ProductStatus { get; set; }
        public DbSet<ProductStatusDetail> ProductStatusDetail { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region ProductCategorySeeding
            ProductCategory pcElectronics = new ProductCategory
            {
                Id = 1,
                Name = "Electronics",
                ParentCategoryId = 0,
            };

            ProductCategory pcGrocery = new ProductCategory
            {
                Id = 2,
                Name = "Grocery",
                ParentCategoryId = 0,
            };

            ProductCategory pcFridges = new ProductCategory
            {
                Id = 3,
                Name = "Fridges",
                ParentCategoryId = 1,
            };

            ProductCategory pcLEDTVs = new ProductCategory
            {
                Id = 4,
                Name = "LED TVs",
                ParentCategoryId = 1,
            };

            ProductCategory pcFrozenItems = new ProductCategory
            {
                Id = 5,
                Name = "Frozen Items",
                ParentCategoryId = 2,
            };

            ProductCategory pcBeverages = new ProductCategory
            {
                Id = 6,
                Name = "Beverages",
                ParentCategoryId = 2,
            };

            modelBuilder.Entity<ProductCategory>().Property(pc => pc.IsDeleted).HasDefaultValue(false);
            modelBuilder.Entity<ProductCategory>().Property(pc => pc.ParentCategoryId).HasDefaultValue(0);
            modelBuilder.Entity<ProductCategory>().HasData(pcElectronics, pcGrocery, pcFridges, pcLEDTVs, pcFrozenItems, pcBeverages);
            #endregion

            #region ProductsSeeding
            Product fridge1 = new Product
            {
                Id = 1,
                Name = "RZ32M72407F 1Door with Convertible Mode, Lamb Freeze, 315L",
                Description = "RZ32M72407F/SG",
                Barcode = "UPC 036725590045",
                Weight = 78,
                ProductCategoryId = pcFridges.Id,
                WeightType = WeightType.KGS,
                Price = 89000
            };

            Product fridge2 = new Product
            {
                Id = 2,
                Name = "RT29K5030S8/ES Top Freezer with Twin Cooling Plus™, 299L",
                Description = "RT29K5030S8/ES",
                Barcode = "UPC 036725596543",
                Weight = 56,
                ProductCategoryId = pcFridges.Id,
                WeightType = WeightType.KGS,
                Price = 119000
            };

            Product ledTV1 = new Product
            {
                Id = 3,
                Name = "Q60A QLED 4K Smart TV",
                Description = "QA55Q60AAUXMM",
                Barcode = "UPC 036725593647",
                Weight = 36,
                ProductCategoryId = pcFridges.Id,
                WeightType = WeightType.KGS,
                Price = 125000
            };

            Product ledTV2 = new Product
            {
                Id = 4,
                Name = "AU9000 Crystal UHD 4K Smart TV",
                Description = "UA65AU9000UXMM",
                Barcode = "UPC 036725593019",
                Weight = 48,
                ProductCategoryId = pcFridges.Id,
                WeightType = WeightType.KGS,
                Price = 149000
            };

            Product frozenItem1 = new Product
            {
                Id = 5,
                Name = "Sabroso Nuggets",
                Description = "Chicken Nuggets",
                Barcode = "UPC 036725931648",
                Weight = 820,
                ProductCategoryId = pcFridges.Id,
                WeightType = WeightType.GRAMS,
                Price = 745
            };

            Product frozenItem2 = new Product
            {
                Id = 6,
                Name = "Sufi Boneless Thigh",
                Description = "Chicken Thighs",
                Barcode = "UPC 0367259346258",
                Weight = 500,
                ProductCategoryId = pcFridges.Id,
                WeightType = WeightType.GRAMS,
                Price = 392
            };

            Product beverages1 = new Product
            {
                Id = 7,
                Name = "Coca Cola",
                Description = "1.5 lt",
                Barcode = "UPC 0367259956320",
                Weight = 1.5,
                ProductCategoryId = pcBeverages.Id,
                WeightType = WeightType.LITRES,
                Price = 95
            };

            Product beverages2 = new Product
            {
                Id = 8,
                Name = "Pepsi",
                Description = "500 mt",
                Barcode = "UPC 0367259564720",
                Weight = 500,
                ProductCategoryId = pcBeverages.Id,
                WeightType = WeightType.MILLILITRES,
                Price = 50
            };

            modelBuilder.Entity<Product>().HasData(fridge1, fridge2, ledTV1, ledTV2, frozenItem1, frozenItem2, beverages1, beverages2);
            modelBuilder.Entity<Product>().Property(pc => pc.IsDeleted).HasDefaultValue(false);
            modelBuilder.Entity<Product>().HasAlternateKey(p => p.Barcode).HasName("SK_Barcode");
            #endregion

            #region ProductStatusSeeding
            ProductStatus inStock = new ProductStatus
            {
                Id = 1,
                Status = ProductStatuses.IN_STOCK
            };

            ProductStatus sold = new ProductStatus
            {
                Id = 2,
                Status = ProductStatuses.SOLD
            };

            ProductStatus damaged = new ProductStatus
            {
                Id = 3,
                Status = ProductStatuses.DAMAGED
            };

            modelBuilder.Entity<ProductStatus>().Property(r => r.Status).HasConversion<string>();
            modelBuilder.Entity<ProductStatus>().HasData(inStock, sold, damaged);
            #endregion

            #region ProductStatusDetailSeeding
            modelBuilder.Entity<ProductStatusDetail>().HasKey(a => new { a.ProductId, a.ProductStatusId });
            modelBuilder.Entity<ProductStatusDetail>().HasData(
                new ProductStatusDetail
                {
                    ProductId = 1,
                    ProductStatusId = (int)ProductStatuses.IN_STOCK,
                    Quantity = 10
                },
                new ProductStatusDetail
                {
                    ProductId = 1,
                    ProductStatusId = (int)ProductStatuses.DAMAGED,
                    Quantity = 0
                },
                new ProductStatusDetail
                {
                    ProductId = 1,
                    ProductStatusId = (int)ProductStatuses.SOLD,
                    Quantity = 0
                },
                new ProductStatusDetail
                {
                    ProductId = 2,
                    ProductStatusId = (int)ProductStatuses.IN_STOCK,
                    Quantity = 10
                },
                new ProductStatusDetail
                {
                    ProductId = 2,
                    ProductStatusId = (int)ProductStatuses.DAMAGED,
                    Quantity = 0
                },
                new ProductStatusDetail
                {
                    ProductId = 2,
                    ProductStatusId = (int)ProductStatuses.SOLD,
                    Quantity = 0
                },
                new ProductStatusDetail
                {
                    ProductId = 3,
                    ProductStatusId = (int)ProductStatuses.IN_STOCK,
                    Quantity = 10
                },
                new ProductStatusDetail
                {
                    ProductId = 3,
                    ProductStatusId = (int)ProductStatuses.DAMAGED,
                    Quantity = 0
                },
                new ProductStatusDetail
                {
                    ProductId = 3,
                    ProductStatusId = (int)ProductStatuses.SOLD,
                    Quantity = 0
                },
                new ProductStatusDetail
                {
                    ProductId = 4,
                    ProductStatusId = (int)ProductStatuses.IN_STOCK,
                    Quantity = 10
                },
                new ProductStatusDetail
                {
                    ProductId = 4,
                    ProductStatusId = (int)ProductStatuses.DAMAGED,
                    Quantity = 0
                },
                new ProductStatusDetail
                {
                    ProductId = 4,
                    ProductStatusId = (int)ProductStatuses.SOLD,
                    Quantity = 0
                },
                new ProductStatusDetail
                {
                    ProductId = 5,
                    ProductStatusId = (int)ProductStatuses.IN_STOCK,
                    Quantity = 10
                },
                new ProductStatusDetail
                {
                    ProductId = 5,
                    ProductStatusId = (int)ProductStatuses.DAMAGED,
                    Quantity = 0
                },
                new ProductStatusDetail
                {
                    ProductId = 5,
                    ProductStatusId = (int)ProductStatuses.SOLD,
                    Quantity = 0
                },
                new ProductStatusDetail
                {
                    ProductId = 6,
                    ProductStatusId = (int)ProductStatuses.IN_STOCK,
                    Quantity = 10
                },
                new ProductStatusDetail
                {
                    ProductId = 6,
                    ProductStatusId = (int)ProductStatuses.DAMAGED,
                    Quantity = 0
                },
                new ProductStatusDetail
                {
                    ProductId = 6,
                    ProductStatusId = (int)ProductStatuses.SOLD,
                    Quantity = 0
                },
                new ProductStatusDetail
                {
                    ProductId = 7,
                    ProductStatusId = (int)ProductStatuses.IN_STOCK,
                    Quantity = 10
                },
                new ProductStatusDetail
                {
                    ProductId = 7,
                    ProductStatusId = (int)ProductStatuses.DAMAGED,
                    Quantity = 0
                },
                new ProductStatusDetail
                {
                    ProductId = 7,
                    ProductStatusId = (int)ProductStatuses.SOLD,
                    Quantity = 0
                },
                new ProductStatusDetail
                {
                    ProductId = 8,
                    ProductStatusId = (int)ProductStatuses.IN_STOCK,
                    Quantity = 10
                },
                new ProductStatusDetail
                {
                    ProductId = 8,
                    ProductStatusId = (int)ProductStatuses.DAMAGED,
                    Quantity = 0
                },
                new ProductStatusDetail
                {
                    ProductId = 8,
                    ProductStatusId = (int)ProductStatuses.SOLD,
                    Quantity = 0
                }
                );
            #endregion
        }

        private ProductStatusDetail GetProductStatusDetail(int productId, ProductStatuses productStatus, int quantity)
        {
            ProductStatusDetail productStatusDetail = new ProductStatusDetail();

            productStatusDetail.ProductId = productId;
            productStatusDetail.ProductStatusId = (int)productStatus;
            productStatusDetail.Quantity = quantity;

            return productStatusDetail;
        }
    }
}

