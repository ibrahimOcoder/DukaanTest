using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsAPI.Model;
using ProductsAPI.Modules.ProductModule.Models.Requests;
using ProductsAPI.Modules.ProductModule.Repositories;
using System.Linq;
using System.Net;

namespace ProductsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [Route("GetProductsWithStatus")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesDefaultResponseType]
        public IActionResult GetProductsWithStatus(ProductStatuses ProductStatus)
        {
            IQueryable products = productRepository.GetProductsWithStatus((int)ProductStatus);
            return new OkObjectResult(products);
        }

        [HttpPatch()]
        [Route("ChangeProductStatus")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesDefaultResponseType]
        public IActionResult ChangeProductStatus([FromBody()] ChangeProductStatus changeProductStatus)
        {
            var products = productRepository.ChangeProductStatus(changeProductStatus.productId, changeProductStatus.oldStatus, changeProductStatus.newStatus);

            if (products)
                return new NoContentResult();
            else
                return new NotFoundResult();
        }

        [HttpPatch()]
        [Route("SellProduct")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public IActionResult SellProduct([FromBody()] ChangeProductStatus changeProductStatus)
        {
            var products = productRepository.SellProduct(changeProductStatus.productId);

            if (products)
                return new NoContentResult();
            else
                return new NotFoundResult();
        }
    }
}
