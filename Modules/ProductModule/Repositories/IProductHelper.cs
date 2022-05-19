using ProductsAPI.DBContexts;
using ProductsAPI.Model;
using System.Threading.Tasks;

namespace ProductsAPI.Modules.ProductModule.Repositories
{
    public interface IProductHelper
    {
        bool ChangeProductStatus(int productId, ProductStatuses oldStatus, ProductStatuses newStatus, ProductContext dbContext);
    }
}
