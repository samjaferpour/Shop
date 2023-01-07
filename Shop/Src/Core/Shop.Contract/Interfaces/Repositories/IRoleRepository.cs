using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Contract.Interfaces.Repositories
{
    public interface IRoleRepository
    {
        Task InsertAsync(Role role);
        Task<Role> UpdateAsync(Guid id, Role role);
        Task<Role> DeleteAsync(Role role);
        Task<Role> GetByIdAsync(Guid id);
        Task<IEnumerable<Role>> GetAllAsync();

    }
}
