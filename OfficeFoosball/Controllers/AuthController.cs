using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OfficeFoosball.Models.Auth;
using OfficeFoosball.Security.Authentication;

namespace OfficeFoosball.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        //api/auth/Register
        public AuthController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody]Register register)
        {
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
                return BadRequest(loginResult.ToString());

            return Ok(loginResult.Data);
        }

    }
}
