using OfficeFoosball.DAL.Entities;

namespace OfficeFoosball.Extensions
{
    public static class MatchExtensions
    {
        public static bool HasParticipant(this Match match, Team team)
            => match.TeamRed == team.Id || match.TeamYellow == team.Id;
    }
}
