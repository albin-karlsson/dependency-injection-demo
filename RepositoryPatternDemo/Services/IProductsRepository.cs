using RepositoryPatternDemo.Models;

namespace RepositoryPatternDemo.Services
{
    public interface IProductsRepository
    {
        public IEnumerable<Product> GetProducts();
        public Product GetProductById(int id);
        /// <summary>
        /// Use this method to add a product to the database and send back all the products, including the new one
        /// </summary>
        /// <param name="product"></param>
        /// <returns>All the products in the database, including the newly added one</returns>
        public IEnumerable<Product> AddProduct(Product product);
    }
}
