using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OfficeFoosball.DAL;
using OfficeFoosball.Helpers;

namespace OfficeFoosball.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class TeamController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TeamController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet()]
        public async Task<IEnumerable<Models.Team>> Get()
        {
            var players = await _unitOfWork.Players.GetAsync();
            return (await _unitOfWork.Teams.GetAsync())?.Select(t =>Mapper.Map(t, players)).OrderBy(t => t.Name) ?? Enumerable.Empty<Models.Team>();
        }

        [HttpGet("{id}")]
        public async Task<Models.Team> Get(int id)
        {
            var team = await _unitOfWork.Teams.GetAsync(id);
            var players = await _unitOfWork.Players.GetAsync(team.PlayerIds);
            return team != null ? Mapper.Map(team, players) : null;

        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]Models.CreateTeam team)
        {
            if (!TryValidateModel(team))
                return BadRequest("Team data not valid");

            var mappedTeam = Mapper.Map(team);
            var createdTeam = _unitOfWork.Teams.CreateTeam(mappedTeam);
            await _unitOfWork.SaveAsync();

            return Created($"Team/{createdTeam.Id}", createdTeam);
        }
    }
}
