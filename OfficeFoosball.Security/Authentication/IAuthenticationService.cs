using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using OfficeFoosball.Security.Authentication.Token;

namespace OfficeFoosball.Security.Authentication
{
    public interface IAuthenticationService
    {
        Task<SecurityResult> RegisterAsync(string username, string email, string password);
        Task<SecurityResult<TokenBatch>> LoginAsync(string userName, string password);  
        Task<TokenBatch> RefreshTokenAsync(string accessToken, string refreshToken);    
    }
}
