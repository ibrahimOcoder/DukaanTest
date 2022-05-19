using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsAPI.Model.Entity
{
    public class ProductStatusDetail
    {
        [Required]
        [Key]
        [ForeignKey("FK_ProductStatus_Product")]
        public int ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        [Key]
        [ForeignKey("FK_ProductStatus_Status")]
        public int ProductStatusId { get; set; }
    }
}
