namespace OfficeFoosball.Helpers
{
    public static class Mapper
    {
        public static Models.Player Map (DAL.Player player)
            => new Models.Player(player.Id, player.Name);
        public static Models.Team Map(DAL.Team team)
            => new Models.Team(team.Id, team.Name, team.Player1Id, team.Player2Id);
    }
}
