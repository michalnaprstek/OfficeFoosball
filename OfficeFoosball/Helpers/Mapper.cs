using System;
using System.Collections.Generic;
using System.Linq;
using OfficeFoosball.Models;

namespace OfficeFoosball.Helpers
{
    public static class Mapper
    {
        public static Models.Player Map (DAL.Entities.Player player)
            => new Models.Player(player.Id, player.Name);

        public static DAL.Entities.Player Map(Models.Player player)
            => new DAL.Entities.Player(player.Name);
        public static Models.Team Map(DAL.Entities.Team team)
            => new Models.Team(team.Id, team.Name, team.Player1Id, team.Player2Id);
        public static Models.Match Map(DAL.Entities.Match match)
            => new Models.Match(match.Id, match.YellowTeamId, match.RedTeamId, match.YellowTeamScore, match.RedTeamScore, match.Note);
        public static DAL.Entities.Match Map(Models.Match match)
            => new DAL.Entities.Match(match.Id, match.YellowTeamId, match.RedTeamId, match.YellowScore, match.RedScore, match.Note);

        internal static MatchListItem Map(DAL.Entities.Match match, IEnumerable<DAL.Entities.Team> teams, IEnumerable<DAL.Entities.Player> players)
        {
            var yellowTeam = teams.Single(x => x.Id == match.YellowTeamId);
            var yellowTeamDesc = $"{yellowTeam.Name}{Environment.NewLine}({players.Single(x => x.Id == yellowTeam.Player1Id).Name} + {players.Single(x => x.Id == yellowTeam.Player2Id).Name})";


            var redTeam = teams.Single(x => x.Id == match.RedTeamId);
            var redTeamDesc = $"{redTeam.Name}{Environment.NewLine}({players.Single(x => x.Id == redTeam.Player1Id).Name} + {players.Single(x => x.Id == redTeam.Player2Id).Name})";

            var winner = match.WinnerTeamId == match.YellowTeamId
                ? "yellow"
                : "red";

            return new MatchListItem(
                match.Id,
                yellowTeamDesc,
                redTeamDesc,
                match.YellowTeamScore,
                match.RedTeamScore,
                winner,
                match.PlayedOn,
                match.Note
                );
        }
    }
}
