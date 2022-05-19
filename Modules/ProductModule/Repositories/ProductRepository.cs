using ProductsAPI.DBContexts;
using ProductsAPI.Model;
using ProductsAPI.Model.Entity;
using ProductsAPI.Modules.ProductModule.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsAPI.Modules.ProductModule.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext dbContext;
        private readonly IProductHelper iProductHelper;

        public ProductRepository(ProductContext dbContext, IProductHelper iProductHelper)
        {
            this.dbContext = dbContext;
            this.iProductHelper = iProductHelper;
        }

        public bool ChangeProductStatus(int productId, ProductStatuses oldStatus, ProductStatuses newStatus)
        {
            return iProductHelper.ChangeProductStatus(productId, oldStatus, newStatus, dbContext);
        }

        public IQueryable<ProductWithStatus> GetProductsWithStatus(int productStatus)
        {
            return (from o in dbContext.Products
                    join x in dbContext.ProductStatusDetail on o.Id equals x.ProductId
                    join y in dbContext.ProductStatus on x.ProductStatusId equals y.Id
                    where y.Id == (productStatus != 0 ? productStatus : y.Id)
                    select new ProductWithStatus
                    {
                        ProductId = o.Id,
                        ProductName = o.Name,
                        ProductStatus = y.Status,
                        ProductCount = x.Quantity,
                    }).AsQueryable();
        }

        public bool SellProduct(int productId)
        {
            return iProductHelper.ChangeProductStatus(productId, ProductStatuses.IN_STOCK, ProductStatuses.SOLD, dbContext);
        }
    }
}
