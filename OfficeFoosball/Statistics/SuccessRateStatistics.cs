using System;
using OfficeFoosball.DAL.Entities;
using OfficeFoosball.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace OfficeFoosball.Statistics
{
    public class SuccessRateStatistics
    {
        
        protected int RankingLimitMatchCount = 5;
        protected TimeSpan RankingLimitTimeInterval = TimeSpan.FromDays(21);
        
        protected bool HasRanking(List<Match> matches) =>
            MatchCountInRankingInterval(matches) >= RankingLimitMatchCount;

        protected int MatchCountInRankingInterval(List<Match> matches) =>
            matches.Count(x => x.PlayedOn > DateTime.Today.Subtract(RankingLimitTimeInterval));

        protected static double CalculateSuccessPercentage(int totalMatchCount, int winCount)
        {
            if (totalMatchCount == 0)
                return 0;

            return 100 * winCount / (double)totalMatchCount;
        }


        protected static List<Match>  GetTeamMatches(List<Match> matches, Team team)
            => matches.Where(m => m.HasParticipant(team)).ToList();

        protected static int GetTeamWins(List<Match> matches, Team team)
            => matches.Count(m => m.HasParticipant(team) && m.WinnerTeamId == team.Id);
    }
}
