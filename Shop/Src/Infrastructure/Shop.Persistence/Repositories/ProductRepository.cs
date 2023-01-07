using Microsoft.EntityFrameworkCore;
using Shop.Contract.Interfaces.Repositories;
using Shop.Domain.Entities;
using Shop.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShopDbContext _context;

        public ProductRepository(ShopDbContext context)
        {
            this._context = context;
        }
        public async Task<Product> DeleteAsync(Guid id)
        {
            var product = await this.GetByIdAsync(id);
            if (product == null)
            {
                return null!;
            }
            _context.Products.Remove(product);
            return product;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var products = await _context.Products.ToListAsync();
            if (products == null)
            {
                return null!;
            }
            return products;
        }

        public async Task<Product> GetByIdAsync(Guid id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return null!;
            }
            return product;
        }

        public async Task InsertAsync(Product product)
        {
            await _context.Products.AddAsync(product);
        }

        public async Task<Product> UpdateAsync(Guid id, Product product)
        {
            var currentProduct = await this.GetByIdAsync(id);
            if (currentProduct == null)
            {
                return null!;
            }
            currentProduct.Name = product.Name;
            currentProduct.Price = product.Price;
            return currentProduct;
        }
    }
}
