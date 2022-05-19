using ProductsAPI.Model;
using ProductsAPI.Model.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsAPI.Modules.ProductModule.Repositories
{
    public interface IProductRepository
    {
        IQueryable<ProductWithStatus> GetProductsWithStatus(int productStatus);

        bool ChangeProductStatus(int productId, ProductStatuses oldStatus, ProductStatuses newStatus);

        bool SellProduct(int productId);
    }
}
