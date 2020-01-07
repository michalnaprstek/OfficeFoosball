using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OfficeFoosball.Models.Auth;
using OfficeFoosball.Security.Authentication;
using OfficeFoosball.Services.AccessCode;

namespace OfficeFoosball.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IAccessCodeService _accessCodeService;

        //api/auth/Register
        public AuthController(IAuthenticationService authenticationService, IAccessCodeService accessCodeService)
        {
            _authenticationService = authenticationService;
            _accessCodeService = accessCodeService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody]Register register)
        {
            if (!TryValidateModel(register))
            {
                var errors = ModelState
                    .Where(a => a.Value.Errors.Count > 0)
                    .SelectMany(x => x.Value.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();
                return BadRequest(string.Join(" ", errors));
            }
            if (!(await _accessCodeService.CheckAccessCodeAsync(register.AccessCode)))
            {
                return BadRequest("Invalid access code. Please ask some of the existing users.");
            }
            var registerResult = await _authenticationService.RegisterAsync(register.Username, register.Email, register.Password);
            if (!registerResult.Succeeded)
                return BadRequest(registerResult.ToString());

            return NoContent();
        }

        //api/auth/Login 
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody]Login login)
        {
            var loginResult = await _authenticationService.LoginAsync(login.Username, login.Password);
            if (!loginResult.Succeeded)
                return Unauthorized(loginResult.ToString());

            return Ok(loginResult.Data);
        }

        [HttpPost("token")]
        public Task<IActionResult> RefreshTokenAsync([FromBody]TokenRefresh tokenRefresh)
        {
            // TODO: implement token refresh
            return Task.FromResult((IActionResult)Unauthorized());
        }

    }
}
