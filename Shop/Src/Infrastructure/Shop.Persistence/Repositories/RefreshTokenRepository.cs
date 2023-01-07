using Shop.Contract.Interfaces.Repositories;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Persistence.Repositories
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        public Task<RefreshToken> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RefreshToken>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<RefreshToken> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task InsertAsync(RefreshToken refreshToken)
        {
            throw new NotImplementedException();
        }

        public Task<RefreshToken> UpdateAsync(Guid id, RefreshToken refreshToken)
        {
            throw new NotImplementedException();
        }
    }
}
