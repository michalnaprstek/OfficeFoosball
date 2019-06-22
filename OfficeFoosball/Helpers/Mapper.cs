namespace OfficeFoosball.Helpers
{
    public static class Mapper
    {
        public static Models.Player Map (DAL.Player player)
            => new Models.Player(player.Id, player.Name);
        public static Models.Team Map(DAL.Team team)
            => new Models.Team(team.Id, team.Name, team.Player1Id, team.Player2Id);
        public static Models.Match Map(DAL.Match match)
            => new Models.Match(match.Id, match.YellowTeamId, match.YellowTeamScore, match.RedTeamId, match.RedTeamScore, match.Note);
        public static DAL.Match Map(Models.Match match)
            => new DAL.Match(match.Id, match.YellowTeamId, match.YellowScore, match.RedTeamId, match.RedScore, match.Note);
    }
}
