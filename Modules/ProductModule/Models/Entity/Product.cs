using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsAPI.Model.Entity
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string Description { get; set; }
        [Required]
        [MaxLength(20)]
        public string Barcode { get; set; }
        [Required]
        public double Weight { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        [ForeignKey("FK_Product_Category")]
        public int ProductCategoryId { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
        [Required]
        public WeightType WeightType { get; set; }
        public ICollection<ProductStatusDetail> ProductStatusDetail { get; set; }
    }
}
