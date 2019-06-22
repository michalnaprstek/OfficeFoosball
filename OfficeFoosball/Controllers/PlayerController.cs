using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using OfficeFoosball.DAL;
using OfficeFoosball.Helpers;

namespace OfficeFoosball.Controllers
{
    [Route("api/[controller]")]
    public class PlayerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PlayerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<Models.Player> Get() 
            => _unitOfWork.Players.Get()?.Select(Mapper.Map) ?? Enumerable.Empty<Models.Player>();
    }
}
