using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Contract.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task InsertAsync(Product product);
        Task<Product> UpdateAsync(Guid id, Product product);
        Task<Product> DeleteAsync(Guid id);
        Task<Product> GetByIdAsync(Guid id);
        Task<IEnumerable<Product>> GetAllAsync();
    }
}
