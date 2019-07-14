using OfficeFoosball.DAL;
using OfficeFoosball.Helpers;
using OfficeFoosball.Models.Statistics;
using System.Linq;

namespace OfficeFoosball.Statistics
{
    public class TeamSuccessRateStatistics
    {
        private readonly IFoosballDatabase _db;

        public TeamSuccessRateStatistics(IFoosballDatabase db)
        {
            _db = db;
        }

        public TeamSuccessRate[] Generate()
        {
            var teamStats = _db.Teams.Select(t => new
            {
                Team = t,
                MatchCount = _db.Matches.Where(m => m.TeamRed == t.Id || m.TeamYellow == t.Id).Count(),
                WinCount = _db.Matches.Where(m => (m.TeamRed == t.Id && m.TeamRedScore > m.TeamYellowScore) || (m.TeamYellow == t.Id && m.TeamYellowScore > m.TeamRedScore)).Count(),
            }).ToList();

            return teamStats
                .Select(x => new TeamSuccessRate
                {
                    Team = Mapper.Map(x.Team),
                    SuccessPercentage = CalculateSuccessPercentage(x.MatchCount, x.WinCount)
                })
                .OrderByDescending(x => x.SuccessPercentage)
                .ToArray();
        }

        private double CalculateSuccessPercentage(int totalMatchCount, int winCount)
        {
            if (totalMatchCount == 0)
                return 0;

            return 100 * winCount / (double)totalMatchCount;
        }


    }
}
