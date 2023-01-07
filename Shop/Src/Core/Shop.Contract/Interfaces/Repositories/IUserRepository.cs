using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Contract.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task InsertAsync(User user);
        Task<User> UpdateAsync(Guid id, User user);
        Task<User> DeleteAsync(Guid id);
        Task<User> GetByIdAsync(Guid id);
        Task<IEnumerable<User>> GetAllAsync();
    }
}
