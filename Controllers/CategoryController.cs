using Microsoft.AspNetCore.Mvc;
using product_microservices.Repository;
using product_microservices.Model;

namespace product_microservices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
 
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            var categories = _categoryRepository.GetCategories();
            return new OkObjectResult(categories);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            var category = _categoryRepository.GetCategoryById(id);
            return new OkObjectResult(category);
        }

        [HttpPost]
        public IActionResult PostCategory([FromBody]Category category)
        {
            _categoryRepository.InsertCategory(category);
            return CreatedAtAction(nameof(GetCategoryById), new { id = category.Id }, category);
        }

        [HttpPut]
        public IActionResult PutCategory([FromBody]Category category)
        {
            if (category != null)
            {
                _categoryRepository.UpdateCategory(category);
                return new OkResult();
            }
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            _categoryRepository.DeleteCategory(id);
            return new OkResult();
        }
    }

}
