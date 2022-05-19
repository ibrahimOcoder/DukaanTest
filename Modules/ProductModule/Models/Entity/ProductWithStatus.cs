using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace ProductsAPI.Model.Entity
{
    public class ProductWithStatus
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public int ProductCount { get; set; }
        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public ProductStatuses ProductStatus { get; set; }
    }
}
