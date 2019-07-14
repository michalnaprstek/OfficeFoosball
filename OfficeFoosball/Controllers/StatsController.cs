using Microsoft.AspNetCore.Mvc;
using OfficeFoosball.DAL;
using OfficeFoosball.Models.Statistics;
using OfficeFoosball.Statistics;
using System.Collections.Generic;

namespace OfficeFoosball.Controllers
{
    [Route("api/[controller]")]
    public class StatsController : ControllerBase
    {
        private readonly IDatabaseProvider _databaseProvider;

        public StatsController(IDatabaseProvider databaseProvider)
        {
            _databaseProvider = databaseProvider;
        }

        [HttpGet]
        [Route("team-success-rates")]
        public IEnumerable<TeamSuccessRate> GetTeamsSuccessRatesAsync()
        {
            var stats = new TeamSuccessRateStatistics(_databaseProvider.Get());
            var results = stats.Generate();
            return results;
        }

        [HttpGet]
        [Route("player-success-rates")]
        public IEnumerable<PlayerSuccessRate> GetPlayersSuccessRatesAsync()
        {
            var stats = new PlayerSuccessRateStatistics(_databaseProvider.Get());
            var results = stats.Generate();
            return results;
        }
    }
}
