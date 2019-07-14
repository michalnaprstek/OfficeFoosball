using System;
using Microsoft.AspNetCore.Mvc;
using OfficeFoosball.Models.Auth;


namespace OfficeFoosball.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        //TODO: Implement login
        //api/auth/Login 
        [HttpPost("login")]
        public IActionResult Login([FromBody]Login login)
        {
            var tokenBatch = new TokenBatch
            {
                AccessToken = "fdsfdsfds",
                RefreshToken = "fdsnjjfdjiifdj",
                ExpiredIn = DateTime.UtcNow.AddHours(1)
            };

            return Ok(tokenBatch);
        }

    }
}
