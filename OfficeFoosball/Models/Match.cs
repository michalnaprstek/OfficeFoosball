namespace OfficeFoosball.Models
{
    public class Match
    {
        public Match()
        {
        }

        public Match(int id, int yellowTeamId, int redTeamId, int yellowScore, int redScore, string note)
        {
            Id = id;
            YellowTeamId = yellowTeamId;
            RedTeamId = redTeamId;
            YellowScore = yellowScore;
            RedScore = redScore;
            Note = note;
        }

        public int Id { get; }
        public int YellowTeamId { get; set; }
        public int RedTeamId { get; set; }
        public int YellowScore { get; set; }
        public int RedScore { get; set; }
        public string Note { get; set; }
        public int WinnerTeamId => YellowScore > RedScore
            ? YellowTeamId
            : RedTeamId;
    }
}
