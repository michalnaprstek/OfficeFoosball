using System.Collections.Generic;
using System.Linq;
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
        public IEnumerable<Models.Team> Get()
            => _unitOfWork.Teams.Get()?.Select(Mapper.Map) ?? Enumerable.Empty<Models.Team>();

        [HttpGet("{id}")]
        public Models.Team Get(int id)
        {
            var team = _unitOfWork.Teams.Get(id);
            return team != null ? Mapper.Map(team) : null;

        }
    }
}
