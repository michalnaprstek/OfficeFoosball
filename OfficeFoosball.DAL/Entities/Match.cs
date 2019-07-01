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
            TeamYellow = yellowTeamId;
            TeamRed = redTeamId;
            TeamYellowScore = yellowTeamScore;
            TeamRedScore = redTeamScore;
            Note = note;
        }

        public int TeamYellow { get; set; }
        public int TeamRed { get; set; }
        public int TeamYellowScore { get; set; }
        public int TeamRedScore { get; set; }
        public string Note { get; set; }
        public DateTime PlayedOn { get; set; }
        public int WinnerTeamId => TeamYellowScore > TeamRedScore
            ? TeamYellow
            : TeamRed;
    }
}
