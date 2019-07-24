using OfficeFoosball.DAL.Entities;
using System.Threading.Tasks;

namespace OfficeFoosball.DAL.Repositories
{
    public interface ITokenRepository
    {
        void CreateRefreshToken(string token, string userId);
        Task<RefreshToken> GetValidRefreshTokenAsync(string userId); 
    }
}
