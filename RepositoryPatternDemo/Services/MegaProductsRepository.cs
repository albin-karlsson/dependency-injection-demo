using RepositoryPatternDemo.Database;
using RepositoryPatternDemo.Models;

namespace RepositoryPatternDemo.Services
{
    public class MegaProductsRepository : IProductsRepository
    {
        private readonly AppDbContext context;

        public MegaProductsRepository(AppDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Use this method to add a product to the database and send back all the products, including the new one
        /// </summary>
        /// <param name="product"></param>
        /// <returns>All the products in the database, including the newly added one</returns>
        public IEnumerable<Product> AddProduct(Product product)
        {
            context.Products.Add(product);

            context.SaveChanges();

            return GetProducts();
        }

        public Product GetProductById(int id)
        {
            Product? product = context.Products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                throw new NullReferenceException();
            }

            return product;
        }

        public IEnumerable<Product> GetProducts()
        {
            return context.Products.ToList();
        }
    }
}
