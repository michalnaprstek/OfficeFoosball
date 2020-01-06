using System;
using System.Collections.Generic;
using System.Linq;
using OfficeFoosball.Models;

namespace OfficeFoosball.Helpers
{
    public static class Mapper
    {
        public static Models.Player Map (DAL.Entities.Player player)
            => new Models.Player(player.Id, player.Nick);

        public static DAL.Entities.Player Map(Models.CreatePlayer player)
            => new DAL.Entities.Player(0, player.Name);
        public static DAL.Entities.Team Map(Models.CreateTeam team)
            => new DAL.Entities.Team(0, team.Name, team.Player1Id.Value, team.Player2Id.Value);
        public static Models.Team Map(DAL.Entities.Team team, IEnumerable<DAL.Entities.Player> players)
            => new Models.Team(team.Id, team.TeamName, Map(players.Single(p => p.Id == team.Player1)), Map(players.Single(p => p.Id == team.Player2)));
        public static Models.Match Map(DAL.Entities.Match match)
            => new Models.Match(match.Id, match.TeamYellow, match.TeamRed, match.TeamYellowScore, match.TeamRedScore, match.Note);
        public static DAL.Entities.Match Map(Models.Match match)
            => new DAL.Entities.Match(match.Id, match.YellowTeamId, match.RedTeamId, match.YellowScore, match.RedScore, match.Note);

        public static Models.User Map(DAL.Entities.User user)
            => new User { Name = user.UserName, Id = user.Id, Email = user.Email, IsApproved = user.IsApproved };

        internal static MatchListItem Map(DAL.Entities.Match match, IEnumerable<DAL.Entities.Team> teams, IEnumerable<DAL.Entities.Player> players)
        {
            var yellowTeam = Map(teams.Single(x => x.Id == match.TeamYellow), players);
            var redTeam = Map(teams.Single(x => x.Id == match.TeamRed), players);

            var winner = match.WinnerTeamId == match.TeamYellow
                ? "yellow"
                : "red";

            return new MatchListItem(
                match.Id,
                yellowTeam,
                redTeam,
                match.TeamYellowScore,
                match.TeamRedScore,
                winner,
                match.PlayedOn,
                match.Note
                );
        }
    }
}
