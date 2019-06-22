namespace OfficeFoosball.DAL
{
    public class Match
    {
        public Match()
        {
        }

        public Match(int id, int yellowTeamId, int redTeamId, int yellowTeamScore, int redTeamScore, string note)
        {
            Id = id;
            YellowTeamId = yellowTeamId;
            RedTeamId = redTeamId;
            YellowTeamScore = yellowTeamScore;
            RedTeamScore = redTeamScore;
            Note = note;
        }

        public int Id { get; set; }
        public int YellowTeamId { get; set; }
        public int RedTeamId { get; set; }
        public int YellowTeamScore { get; set; }
        public int RedTeamScore { get; set; }
        public string Note { get; set; }
        public int WinnerTeamId => YellowTeamScore > RedTeamScore
            ? YellowTeamId
            : RedTeamId;
    }
}
