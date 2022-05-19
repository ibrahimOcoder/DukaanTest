using ProductsAPI.Model.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductsAPI.Model.Entity
{
    public class ProductCategory
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        [Required]
        public int ParentCategoryId { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
