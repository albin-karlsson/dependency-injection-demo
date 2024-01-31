using RepositoryPatternDemo.Database;
using RepositoryPatternDemo.Models;

namespace RepositoryPatternDemo.Services
{
    /// <summary>
    /// This is a deprecated repository, since v3 use MegaProductsRepository instead
    /// </summary>
    public class ProductsRepository : IProductsRepository
    {
        private readonly AppDbContext context;

        public ProductsRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Product> AddProduct(Product product)
        {
            context.Products.Add(product);

            context.SaveChanges();

            return GetProducts();
        }

        public Product GetProductById(int id)
        {
            return context.Products.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return context.Products.ToList();
        }
    }
}
