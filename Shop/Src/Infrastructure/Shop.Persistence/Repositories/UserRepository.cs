using Shop.Contract.Interfaces.Repositories;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        public Task<User> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task InsertAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateAsync(Guid id, User user)
        {
            throw new NotImplementedException();
        }
    }
}
