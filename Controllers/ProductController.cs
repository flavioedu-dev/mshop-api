using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mshop_api.Models.DTO;
using mshop_api.Models;
using mshop_api.Services.Interfaces;

namespace mshop_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _products;

        public ProductController(IProductServices products)
        {
            _products = products;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            try
            {
                var products = await _products.GetProducts();
                if (products == null) return BadRequest("Error finding products.");

                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductById(int id)
        {
            try
            {
                var product = await _products.GetProductById(id);
                if (product == null) return NotFound("Product not found.");

                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Product>> AddProduct(Product productData)
        {
            try
            {
                var product = await _products.CreateProduct(productData);

                return CreatedAtAction(nameof(GetProducts), product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, ProductDTO productData)
        {
            try
            {
                if (id != productData.Id) return NotFound("User not found.");

                bool productUpdated = await _products.UpdateProduct(productData);
                if (!productUpdated) return BadRequest("Error updating product.");

                return Ok("Product updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                bool productDeleted = await _products.DeleteProduct(id);
                if (!productDeleted) return BadRequest("Error deleting product.");

                return Ok("Product deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
