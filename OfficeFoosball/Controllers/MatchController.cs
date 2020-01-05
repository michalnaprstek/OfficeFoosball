using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfficeFoosball.DAL;
using OfficeFoosball.Extensions;
using OfficeFoosball.Helpers;

namespace OfficeFoosball.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class MatchController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public MatchController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IEnumerable<Models.MatchListItem>> GetAsync()
        {
            var teams = await _unitOfWork.Teams.GetAsync();
            var players = await _unitOfWork.Players.GetAsync();

            return (await _unitOfWork.Matches.GetAsync())
                .OrderByDescending(x => x.PlayedOn)
                .Select(x => Mapper.Map(x, teams, players));
        }

        [HttpGet("today")]
        public async Task<IEnumerable<Models.MatchListItem>> GetTodayAsync()
        {
            var today = DateTime.Today;
            var teams = await _unitOfWork.Teams.GetAsync();
            var players = await _unitOfWork.Players.GetAsync();

            return (await _unitOfWork.Matches.GetAsync(today))
                .Select(x => Mapper.Map(x, teams, players));
        }

        [HttpGet("previousday")]
        public async Task<IEnumerable<Models.MatchListItem>> GetPreviousDayAsync()
        {
            var day = DateTime.Today.GetPreviousWorkingDay();
            var teams = await _unitOfWork.Teams.GetAsync();
            var players = await _unitOfWork.Players.GetAsync();

            return (await _unitOfWork.Matches.GetAsync(day))
                .Select(x => Mapper.Map(x, teams, players));
        }

        [HttpGet("{id}")]
        public async Task<Models.Match> GetAsync(int id)
        {
            var match = await _unitOfWork.Matches.GetAsync(id);
            return match != null ? Mapper.Map(match) : null;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Models.Match match)
        {
            await _unitOfWork.Matches.UpdateAsync(Mapper.Map(match));
            await _unitOfWork.SaveAsync();
            return Created($"Match/{match.Id}", match);
        }
    }
}
