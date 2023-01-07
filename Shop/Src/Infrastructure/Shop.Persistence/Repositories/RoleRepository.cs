using Shop.Contract.Interfaces.Repositories;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Persistence.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        public Task<Role> DeleteAsync(Role role)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Role>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Role> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task InsertAsync(Role role)
        {
            throw new NotImplementedException();
        }

        public Task<Role> UpdateAsync(Guid id, Role role)
        {
            throw new NotImplementedException();
        }
    }
}
