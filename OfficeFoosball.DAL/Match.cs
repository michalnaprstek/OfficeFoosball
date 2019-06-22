namespace OfficeFoosball.DAL
{
    public class Match
    {
        public int Id { get; set; }
        public int YellowTeamId { get; set; }
        public int RedTeamId { get; set; }
        public int YellowTeamGoalCount { get; set; }
        public int RedTeamGoalCount { get; set; }
        public string Note { get; set; }
        public int WinnerTeamId => YellowTeamGoalCount > RedTeamGoalCount
            ? YellowTeamId
            : RedTeamId;
    }
}
