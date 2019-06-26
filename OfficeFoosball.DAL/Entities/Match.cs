using System;

namespace OfficeFoosball.DAL.Entities
{
    public class Match : Entity
    {
        public Match()
        {
        }

        public Match(int id, int yellowTeamId, int redTeamId, int yellowTeamScore, int redTeamScore, string note) 
            : base(id)
        {
            YellowTeamId = yellowTeamId;
            RedTeamId = redTeamId;
            YellowTeamScore = yellowTeamScore;
            RedTeamScore = redTeamScore;
            Note = note;
        }

        public int YellowTeamId { get; set; }
        public int RedTeamId { get; set; }
        public int YellowTeamScore { get; set; }
        public int RedTeamScore { get; set; }
        public string Note { get; set; }
        public DateTime PlayedOn { get; set; }
        public int WinnerTeamId => YellowTeamScore > RedTeamScore
            ? YellowTeamId
            : RedTeamId;
    }
}
