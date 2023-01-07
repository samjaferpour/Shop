using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Contract.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        Task InsertAsync(Category category);
        Task<Category> UpdateAsync(Guid id, Category category);
        Task<Category> DeleteAsync(Guid id);
        Task<Category> GetByIdAsync(Guid id);
        Task<IEnumerable<Category>> GetAllAsync();
    }
}
