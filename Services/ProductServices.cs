using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mshop_api.Context;
using mshop_api.Models;
using mshop_api.Models.DTO;
using mshop_api.Services.Interfaces;

namespace mshop_api.Services
{
    public class ProductServices : IProductServices
    {
        private readonly AppDbContext _context;

        public ProductServices(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            try
            {
                IEnumerable<Product> products = await _context.products.ToListAsync();
                if (products == null) throw new Exception("Error finding products.");

                return products;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Product> GetProductById(int id)
        {
            try
            {
                Product product = await _context.products.FirstOrDefaultAsync(x => x.Id == id);
                if (product == null) throw new Exception("Error finding product.");

                return product;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Product> CreateProduct([FromBody] Product product)
        {
            try
            {
                var productAdded = await _context.products.AddAsync(product);
                if (productAdded == null) throw new Exception("Error finding product.");

                await _context.SaveChangesAsync();

                return product;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateProduct([FromBody] ProductDTO product)
        {
            {
                try
                {
                    Product productExists = await GetProductById(product.Id);
                    if (productExists == null) throw new Exception("Product not registered.");

                    productExists.Name = product.Name;
                    productExists.Price = product.Price;
                    productExists.Amount = product.Amount;

                    await _context.SaveChangesAsync();

                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<bool> DeleteProduct(int id)
        {
            try
            {
                Product productExists = await GetProductById(id);
                if (productExists == null) throw new Exception("Product not registered.");

                _context.Remove(productExists);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
