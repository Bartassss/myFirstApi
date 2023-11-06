using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace myFirstApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static List<Product> products = new List<Product>
            {
     
            };

        private readonly DataContext Context;

        public ProductController(DataContext context)
        {
            Context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {
            return Ok(await Context.Products.ToListAsync());
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<List<Product>>> Get(Guid Id)
        {
           var product = await Context.Products.FindAsync(Id);
            if (product == null)
                return BadRequest("Product not found.");
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<List<Product>>> AddProduct(Product product)
        {
            Context.Products.Add(product);
            await Context.SaveChangesAsync();
            return Ok(product.Id);
        }

        [HttpPut]
        public async Task<ActionResult<List<Product>>> UpdateProduct(Product request)
        {
            var dbProduct = await Context.Products.FindAsync(request.Id);
            if (dbProduct == null)
                return BadRequest("Product not found.");

            dbProduct.Description = request.Description;
            dbProduct.Quantity = request.Quantity;

            await Context.SaveChangesAsync();

            return Ok(await Context.Products.ToListAsync());
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<List<Product>>> Delete(Guid Id)
        {
            var dbProduct = await Context.Products.FindAsync(Id);
            if (dbProduct == null)
                return BadRequest("Product not found.");

            Context.Products.Remove(dbProduct);
            await Context.SaveChangesAsync();
            return Ok("Succesfully deleted.");
        }
    }
}
