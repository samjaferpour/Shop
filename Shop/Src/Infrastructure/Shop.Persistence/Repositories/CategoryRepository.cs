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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ShopDbContext _context;

        public CategoryRepository(ShopDbContext context) 
        {
            this._context = context;
        }
        public async Task<Category> DeleteAsync(Guid id)
        {
            var category = await this.GetByIdAsync(id);
            if (category == null)
            {
                return null!;
            }
            _context.Categories.Remove(category);
            return category;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            var categories = await _context.Categories.AsNoTracking().ToListAsync();
            if (categories == null)
            {
                return null!;
            }
            return categories;
        }

        public async Task<Category> GetByIdAsync(Guid id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return null!;
            }
            return category;
        }

        public async Task InsertAsync(Category category)
        {
            await _context.AddAsync(category);
        }

        public async Task<Category> UpdateAsync(Guid id, Category category)
        {
            var currentCategory = await this.GetByIdAsync(id);
            if (currentCategory == null)
            {
                return null!;
            }
            currentCategory.Name= category.Name;
            return currentCategory;
        }
    }
}
