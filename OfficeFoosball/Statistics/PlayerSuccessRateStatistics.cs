using OfficeFoosball.DAL;
using OfficeFoosball.DAL.Entities;
using OfficeFoosball.Extensions;
using OfficeFoosball.Helpers;
using OfficeFoosball.Models.Statistics;
using System.Collections.Generic;
using System.Linq;

namespace OfficeFoosball.Statistics
{
    public class PlayerSuccessRateStatistics : SuccessRateStatistics
    {
        private readonly IFoosballDatabase _db;

        public PlayerSuccessRateStatistics(IFoosballDatabase db)
        {
            _db = db;
        }

        public PlayerSuccessRate[] Generate()
        {
            var matches = _db.Matches.ToList();

            var teams = _db.Teams.ToList();

            var players = _db.Players.ToList();

            var playerStats = players.Select(player => new
            {
                Player = player,
                Matches = GetPlayerMatches(matches, teams, player),
                Wins = GetPlayerWins(matches, teams, player)
            });

            var result = playerStats
                .Select(x => new PlayerSuccessRate
                {
                    Player = Mapper.Map(x.Player),
                    SuccessPercentage = CalculateSuccessPercentage(x.Matches, x.Wins),
                    TotalMatchCount = x.Matches
                })
                .OrderByDescending(x => x.SuccessPercentage)
                .ToArray();

            return result;
        }

        private int GetPlayerMatches(List<Match> matches, List<Team> teams, Player player)
        {
            var playerTeams = teams.Where(t => t.HasParticipant(player));
            return playerTeams.Sum(team => GetTeamMatches(matches, team));
        }

        private int GetPlayerWins(List<Match> matches, List<Team> teams, Player player)
        {
            var playerTeams = teams.Where(t => t.HasParticipant(player));
            return playerTeams.Sum(team => GetTeamWins(matches, team));
        }
    }
}
