using Microsoft.EntityFrameworkCore;
using product_microservices.DBContexts;
using product_microservices.Model;

namespace product_microservices.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ProductContext _context;
        public CategoryRepository(ProductContext context)
        {
            _context = context;
        }
        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }
        public Category GetCategoryById(int categoryId)
        {
            var category = _context.Categories.Find(categoryId);
            
            if (category == null)
                throw new Exception("Category not found");
            else 
                return category;
        }
        public void DeleteCategory(int categoryId)
        {
            var category = _context.Categories.Find(categoryId);

            if (category == null)
                throw new Exception("Category not found");
            else
            {
                _context.Categories.Remove(category);
            }
            
            Save();
        }

        public void InsertCategory(Category category)
        {
            _context.Categories.Add(category);
            Save();
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        public void UpdateCategory(Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
            Save();
        }
    }
}
