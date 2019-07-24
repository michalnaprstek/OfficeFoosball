using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OfficeFoosball.DAL.Entities;

namespace OfficeFoosball.DAL.Repositories
{
    public class TokenRepository : Repository<RefreshToken>, ITokenRepository
    {
        public TokenRepository(DbSet<RefreshToken> dbSet) : base(dbSet)
        {
        }

        public void CreateRefreshToken(string token, string userId)
        {
            DbSet.Add(new RefreshToken
            {
                Token = token,
                UserId = userId,
                ValidTo = DateTimeOffset.UtcNow.AddYears(2)
            });
        }

        public async Task<RefreshToken> GetValidRefreshTokenAsync(string userId)
        {
            return await DbSet
                .Where(token => token.UserId == userId && token.ValidTo >= DateTimeOffset.UtcNow)
                .FirstOrDefaultAsync();
        }
    }
}
