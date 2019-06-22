using System.Collections.Generic;
using System.Linq;
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
        public IEnumerable<Models.Match> Get()
            => _unitOfWork.Matches.Get().Select(Mapper.Map);

        [HttpGet("{id}")]
        public Models.Match Get(int id)
        {
            var match = _unitOfWork.Matches.Get(id);
            return match != null ? Mapper.Map(match) : null;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Models.Match match)
        {
            _unitOfWork.Matches.Update(Mapper.Map(match));
            _unitOfWork.Save();
            return Ok();
        }
    }
}
