using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OfficeFoosball.DAL;
using OfficeFoosball.Helpers;

namespace OfficeFoosball.Controllers
{
    [Route("api/[controller]")]
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

            return (await _unitOfWork.Matches.GetAsync()).Select(x => Mapper.Map(x, teams, players));
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
            _unitOfWork.Save();
            return Ok();
        }
    }
}
