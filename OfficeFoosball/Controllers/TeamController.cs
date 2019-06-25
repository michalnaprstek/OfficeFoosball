using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        [HttpGet()]
        public async Task<IEnumerable<Models.Team>> Get()
            => (await _unitOfWork.Teams.GetAsync())?.Select(Mapper.Map) ?? Enumerable.Empty<Models.Team>();

        [HttpGet("{id}")]
        public async Task<Models.Team> Get(int id)
        {
            var team = await _unitOfWork.Teams.GetAsync(id);
            return team != null ? Mapper.Map(team) : null;

        }
    }
}
