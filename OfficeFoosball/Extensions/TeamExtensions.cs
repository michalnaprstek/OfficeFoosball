using OfficeFoosball.DAL.Entities;

namespace OfficeFoosball.Extensions
{
    public static class TeamExtensions
    {
        public static bool HasParticipant(this Team team, Player player)
            => team.Player1 == player.Id || team.Player2 == player.Id;
    }
}
