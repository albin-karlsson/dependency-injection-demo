using Microsoft.AspNetCore.Mvc;
using RepositoryPatternDemo.Models;
using RepositoryPatternDemo.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RepositoryPatternDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsRepository repo;

        public ProductsController(IProductsRepository repo)
        {
            this.repo = repo;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public IEnumerable<Product> Get()
        {



            ProductsRepository pr = new();






            return repo.GetProducts();

        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public Product? Get(int id)
        {
            return repo.GetProductById(id);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public IEnumerable<Product> Post(Product newProduct)
        {
            return repo.AddProduct(newProduct);

            // ------------------------------------------------

            // Kontakta databasen för att lägga till en produkt
            // * NY * (Transient)

            // Kontakta databasen för att hämta alla produkter
            // * SAMMA * (Transient)

            // Skicka alla produkter till användaren
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
