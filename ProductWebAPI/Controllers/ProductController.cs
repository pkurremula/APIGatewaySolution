using Microsoft.AspNetCore.Mvc;
using ProductWebAPI.Models;

namespace ProductWebAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly ProductDBContext _productDBContext;

        public ProductController(ProductDBContext productDBContext)
        {
            _productDBContext = productDBContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            return _productDBContext.Products;
        }

        [HttpGet("{productId:int}")]
        public async Task<ActionResult<Product>> GetProductById(int productId)
        {
            var product = await _productDBContext.Products.FindAsync(productId);

            if(product == null)
            {
                return NotFound();
            }

            return product;
        }

        [HttpPost]
        public async Task<ActionResult> Create(Product product)
        {
            await _productDBContext.Products.AddAsync(product);
            await _productDBContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update(Product product)
        {
            _productDBContext.Products.Update(product);
            await _productDBContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{productId:int}")]
        public async Task<ActionResult> Delete(int productId)
        {
            var product = await _productDBContext.Products.FindAsync(productId);
            if (product == null)
            {
                return NotFound();
            }
            _productDBContext.Products.Remove(product);
            await _productDBContext.SaveChangesAsync();
            return Ok();
        }
    }
}
