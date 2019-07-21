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

        public static DAL.Entities.Player Map(Models.Player player)
            => new DAL.Entities.Player(player.Id, player.Name);
        public static DAL.Entities.Team Map(Models.Team team)
            => new DAL.Entities.Team(team.Name, team.Player1Id, team.Player2Id);
        public static Models.Team Map(DAL.Entities.Team team)
            => new Models.Team(team.Id, team.TeamName, team.Player1, team.Player2);
        public static Models.Match Map(DAL.Entities.Match match)
            => new Models.Match(match.Id, match.TeamYellow, match.TeamRed, match.TeamYellowScore, match.TeamRedScore, match.Note);
        public static DAL.Entities.Match Map(Models.Match match)
            => new DAL.Entities.Match(match.Id, match.YellowTeamId, match.RedTeamId, match.YellowScore, match.RedScore, match.Note);

        internal static MatchListItem Map(DAL.Entities.Match match, IEnumerable<DAL.Entities.Team> teams, IEnumerable<DAL.Entities.Player> players)
        {
            var yellowTeam = teams.Single(x => x.Id == match.TeamYellow);
            var yellowTeamDesc = $"{yellowTeam.TeamName}{Environment.NewLine}({players.Single(x => x.Id == yellowTeam.Player1).Nick} + {players.Single(x => x.Id == yellowTeam.Player2).Nick})";


            var redTeam = teams.Single(x => x.Id == match.TeamRed);
            var redTeamDesc = $"{redTeam.TeamName}{Environment.NewLine}({players.Single(x => x.Id == redTeam.Player1).Nick} + {players.Single(x => x.Id == redTeam.Player2).Nick})";

            var winner = match.WinnerTeamId == match.TeamYellow
                ? "yellow"
                : "red";

            return new MatchListItem(
                match.Id,
                yellowTeamDesc,
                redTeamDesc,
                match.TeamYellowScore,
                match.TeamRedScore,
                winner,
                match.PlayedOn,
                match.Note
                );
        }
    }
}
