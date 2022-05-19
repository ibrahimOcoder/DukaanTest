using ProductsAPI.Model;

namespace ProductsAPI.Modules.ProductModule.Models.Requests
{
    public class ChangeProductStatus
    {
        public int productId { get; set; }

        public ProductStatuses oldStatus { get; set; }

        public ProductStatuses newStatus { get; set; }
    }
}
