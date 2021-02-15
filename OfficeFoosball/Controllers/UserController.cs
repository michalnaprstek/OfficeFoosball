using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeFoosball.DAL.Entities;
using OfficeFoosball.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfficeFoosball.Controllers
{
    [Route("api/[controller]")]
    [Authorize]

    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;

        public UserController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IEnumerable<Models.User>> GetAsync()
            => (await _userManager.Users.ToListAsync()).OrderBy(u => u.UserName).Select(Mapper.Map) ?? Enumerable.Empty<Models.User>();

        [HttpGet("not-approved")]
        public async Task<IEnumerable<Models.User>> GetNotApprovedAsync()
            => (await _userManager.Users.Where(x => !x.IsApproved).ToListAsync()).OrderBy(u => u.UserName).Select(Mapper.Map) ?? Enumerable.Empty<Models.User>();
    }
}