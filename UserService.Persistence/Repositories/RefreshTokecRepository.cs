using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UserService.Infrastructure.Identity;
using UserService.Infrastructure.Interfaces.Repositories;

namespace UserService.Persistence.Repositories
{
    public class RefreshTokecRepository(UserDbContext dbContext) : IRefreshTokecRepository
    {
        protected readonly UserDbContext _dbContext = dbContext;
        protected readonly DbSet<RefreshToken> _dbSet = dbContext.RefreshTokens;



        public async Task<RefreshToken> InsertAsync(RefreshToken refreshToken)
        {
            await _dbSet.AddAsync(refreshToken);
            await _dbContext.SaveChangesAsync();

            return refreshToken;
        }



        public async Task<RefreshToken?> GetStoredTokenAsync(string hashedToken) =>
            await _dbSet.Include(x => x.User)
                        .SingleOrDefaultAsync(x => x.TokenHash == hashedToken);



    }
}
