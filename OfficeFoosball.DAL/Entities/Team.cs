namespace OfficeFoosball.DAL.Entities
{
    public class Team : Entity
    {
        public Team(string teamName, int player1Id, int player2Id)
        {
            TeamName = teamName;
            Player1 = player1Id;
            Player2 = player2Id;
        }

        public Team() { }

        public string TeamName { get; set; }
        public int Player1 { get; set; }
        public int Player2 { get; set; }
        public int[] PlayerIds => new [] { Player1, Player2 };
    }
}
