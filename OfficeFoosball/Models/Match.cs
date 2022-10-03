namespace OfficeFoosball.Models
{
    public class Match
    {
        public Match()
        {
        }

        public Match(int id, int team1Id, int team2Id, int team1Score, int team2Score, string note)
        {
            Id = id;
            Team1Id = team1Id;
            Team2Id = team2Id;
            Team1Score = team1Score;
            Team2Score = team2Score;
            Note = note;
        }

        public int Id { get; }
        public int Team1Id { get; set; }
        public int Team2Id { get; set; }
        public int Team1Score { get; set; }
        public int Team2Score { get; set; }
        public string Note { get; set; }
        public int WinnerTeamId => Team1Score > Team2Score
            ? Team1Id
            : Team2Id;
    }
}
