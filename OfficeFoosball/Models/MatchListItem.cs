using System;

namespace OfficeFoosball.Models
{
    public class MatchListItem
    {
        public MatchListItem(int id, Team yellowTeam, Team redTeam, int yellowScore, int redScore, string winner, DateTime played, string note)
        {
            Id = id;
            YellowTeam = yellowTeam;
            RedTeam = redTeam;
            YellowScore = yellowScore;
            RedScore = redScore;
            Winner = winner;
            Played = played.ToString("d.MM.yy HH:mm");
            Note = note;
        }

        public int Id { get; set; }
        public Team YellowTeam { get; set; }
        public Team RedTeam { get; set; }
        public int YellowScore { get; set; }
        public int RedScore { get; set; }
        public string Winner { get; set; }
        public string Played { get; set; }
        public string Note { get; set; }
    }
}
