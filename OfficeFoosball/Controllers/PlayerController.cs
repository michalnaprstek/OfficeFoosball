using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfficeFoosball.DAL;
using OfficeFoosball.Helpers;

namespace OfficeFoosball.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class PlayerController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public PlayerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IEnumerable<Models.Player>> GetAsync() 
            => (await _unitOfWork.Players.GetAsync())?.Select(Mapper.Map).OrderBy(p => p.Name) ?? Enumerable.Empty<Models.Player>();


        [HttpPost]
        [Authorize(Roles = Models.Constants.UserRoles.ADMIN)]
        public async Task<IActionResult> PostAsync([FromBody]Models.Player player)
        {
            var createdPlayer = _unitOfWork.Players.CreatePlayer(Mapper.Map(player));
            await _unitOfWork.SaveAsync();

            return Ok(createdPlayer);
        }
    }
}
