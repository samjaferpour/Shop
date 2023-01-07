using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Contract.Interfaces.Repositories
{
    public interface IRefreshTokenRepository
    {
        Task InsertAsync(RefreshToken refreshToken);
        Task<RefreshToken> UpdateAsync(Guid id, RefreshToken refreshToken);
        Task<RefreshToken> DeleteAsync(Guid id);
        Task<RefreshToken> GetByIdAsync(Guid id);
        Task<IEnumerable<RefreshToken>> GetAllAsync();
    }
}
