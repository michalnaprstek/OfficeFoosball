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
    public class TeamController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TeamController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Authorize]
        [HttpGet()]
        public async Task<IEnumerable<Models.Team>> Get()
        {
            var players = await _unitOfWork.Players.GetAsync();
            return (await _unitOfWork.Teams.GetAsync())?.Select(t =>Mapper.Map(t, players)) ?? Enumerable.Empty<Models.Team>();
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<Models.Team> Get(int id)
        {
            var team = await _unitOfWork.Teams.GetAsync(id);
            var players = await _unitOfWork.Players.GetAsync(team.PlayerIds);
            return team != null ? Mapper.Map(team, players) : null;

        }
    }
}
