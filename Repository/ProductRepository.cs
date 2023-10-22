using product_microservices.DBContexts;
using product_microservices.Model;

namespace product_microservices.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _context;
        public ProductRepository(ProductContext context)
        {
            _context = context;
        }
        public void DeleteProduct(int productId)
        {
            var product = _context.Products.Find(productId);
            if (product != null)
            {
                _context.Products.Remove(product);
                Save();
            }
            else throw new System.Exception("Product not found");
        }
        public Product GetProductById(int productId)
        {
            var product = _context.Products.Find(productId);
            if (product != null)
            {
                return product;
            }
            else throw new System.Exception("Product not found");
        }
        public IEnumerable<Product> GetProducts()
        {
            return _context.Products;
        }
        public void InsertProduct(Product product)
        {
            _context.Add(product);
            Save();
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        public void UpdateProduct(Product product)
        {
            _context.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Save();
        }
    }
}
