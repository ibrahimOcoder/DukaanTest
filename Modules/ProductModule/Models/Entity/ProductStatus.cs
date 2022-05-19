using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductsAPI.Model.Entity
{
    public class ProductStatus
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(10)]
        public ProductStatuses Status { get; set; }
        public ICollection<ProductStatusDetail> ProductStatusDetail { get; set; }
    }
}
