using OfficeFoosball.DAL.Entities;
using OfficeFoosball.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace OfficeFoosball.Statistics
{
    public class SuccessRateStatistics
    {

        protected double CalculateSuccessPercentage(int totalMatchCount, int winCount)
        {
            if (totalMatchCount == 0)
                return 0;

            return 100 * winCount / (double)totalMatchCount;
        }


        protected int GetTeamMatches(List<Match> matches, Team team)
            => matches.Count(m => m.HasParticipant(team));

        protected int GetTeamWins(List<Match> matches, Team team)
            => matches.Count(m => m.HasParticipant(team) && m.WinnerTeamId == team.Id);
    }
}
