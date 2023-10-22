using Microsoft.AspNetCore.Mvc;
using product_microservices.Repository;
using product_microservices.Model;

namespace product_microservices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
 
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _productRepository.GetProducts();
            return new OkObjectResult(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _productRepository.GetProductById(id);
            return new OkObjectResult(product);
        }

        [HttpPost]
        public IActionResult PostProduct([FromBody]Product product)
        {
            _productRepository.InsertProduct(product);
            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
        }

        [HttpPut]
        public IActionResult PutProduct([FromBody]Product product)
        {
            if (product != null)
            {
                _productRepository.UpdateProduct(product);
                return new OkResult();
            }
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            _productRepository.DeleteProduct(id);
            return new OkResult();
        }
    }   
}
