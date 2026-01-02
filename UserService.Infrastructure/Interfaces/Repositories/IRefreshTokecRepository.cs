using System;
using System.Collections.Generic;
using System.Text;
using UserService.Infrastructure.Identity;


namespace UserService.Infrastructure.Interfaces.Repositories
{
    public interface IRefreshTokecRepository
    {
        Task<RefreshToken?> GetStoredTokenAsync(string hashedToken);
        Task<RefreshToken> InsertAsync(RefreshToken refreshToken);
    }
}
