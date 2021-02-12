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

            var teamStats = teams
                .Select(team => new
                {
                    Team = team,
                    WinCount = GetTeamWins(matches, team),
                    Matches = GetTeamMatches(matches, team),
                })
                .Select(x => new TeamSuccessRate
                {
                    Team = Mapper.Map(x.Team, players),
                    SuccessPercentage = CalculateSuccessPercentage(x.Matches.Count, x.WinCount),
                    TotalMatchCount = x.Matches.Count,
                    HasRanking = HasRanking(x.Matches),
                    MatchCountInRanking = MatchCountInRankingInterval(x.Matches)
                })
                .ToArray();

            var result = teamStats
                .Where(x => x.HasRanking)
                .OrderByDescending(x => x.SuccessPercentage)
                .ToList();
            
            result.AddRange(teamStats
                .Where(x => !x.HasRanking && x.MatchCountInRanking > 0)
                .OrderByDescending(x => x.TotalMatchCount)
            );

            return result.ToArray();
        }


    }
}
