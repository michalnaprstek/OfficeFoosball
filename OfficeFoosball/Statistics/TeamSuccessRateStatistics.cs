using OfficeFoosball.DAL;
using OfficeFoosball.Helpers;
using OfficeFoosball.Models.Statistics;
using System.Linq;

namespace OfficeFoosball.Statistics
{
    public class TeamSuccessRateStatistics : SuccessRateStatistics
    {
        private readonly IFoosballDatabase _db;

        public TeamSuccessRateStatistics(IFoosballDatabase db)
        {
            _db = db;
        }

        public TeamSuccessRate[] Generate()
        {
            var matches = _db.Matches.ToList();

            var teams = _db.Teams.ToList();

            var players = _db.Players.ToList();

            var teamStats = teams.Select(team => new
            {
                Team = team,
                WinCount = GetTeamWins(matches, team),
                MatchCount = GetTeamMatches(matches, team),
            });

            return teamStats
                .Select(x => new TeamSuccessRate
                {
                    Team = Mapper.Map(x.Team, players),
                    SuccessPercentage = CalculateSuccessPercentage(x.MatchCount, x.WinCount)
                })
                .OrderByDescending(x => x.SuccessPercentage)
                .ToArray();
        }


    }
}
