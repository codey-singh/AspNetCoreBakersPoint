using BakersPoint.Domain;
using BakersPoint.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BakersPoint.Application
{
    public class ProductService: IProductService
    {
        private readonly IApplicationContext _context;
        
        public ProductService(IApplicationContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<Product>> GetProductsAsync()
             => Task.FromResult(_context.Products.AsEnumerable());
        

        public async Task<Product> GetProductByIdAsync(int id)
            => await _context.Products.FindAsync(id);

        public async Task AddProductAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task AddProductAsync(Product product);
    }
}