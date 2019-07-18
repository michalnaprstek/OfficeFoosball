using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using OfficeFoosball.DAL.Entities;
using OfficeFoosball.Security.Authentication.Token;
using OfficeFoosball.Security.Token;

namespace OfficeFoosball.Security.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;

        public AuthenticationService(UserManager<User> userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<SecurityResult> RegisterAsync(string userName, string email, string password)
        {
            var securityResult = new SecurityResult();

            var user = new User
            {
                UserName = userName,
                Email = email,
                IsApproved = false
            };

            var createUserResult = await _userManager.CreateAsync(user, password);
            if (!createUserResult.Succeeded)
            {
                securityResult.AddErrorMessages(createUserResult.Errors.Select(e => e.Description));
                return securityResult;
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

            var addClaimsResult = await _userManager.AddClaimsAsync(user, claims);
            if (!addClaimsResult.Succeeded)
            {
                securityResult.AddErrorMessages(addClaimsResult.Errors.Select(e => e.Description));
            }

            return securityResult;
        }

        public async Task<SecurityResult<TokenBatch>> LoginAsync(string userName, string password)
        {
            var result = new SecurityResult<TokenBatch>();

            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                result.AddErrorMessage($"{userName} does not exists.");
                return result;
            }

            var verified = _userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, password);
            if (verified == PasswordVerificationResult.Failed)
            {
                result.AddErrorMessage("Invalid password.");
                return result;
            }

            var usersClaims = await _userManager.GetClaimsAsync(user);
            var accessToken = _tokenService.GenerateAccessToken(usersClaims);

            result.Data = new TokenBatch
            {
                AccessToken = accessToken
            };

            return result;
        }

        public Task<TokenBatch> RefreshTokenAsync(string accessToken, string refreshToken)
        {
            throw new System.NotImplementedException();
        }
    }
}