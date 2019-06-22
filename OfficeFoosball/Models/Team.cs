namespace OfficeFoosball.Models
{
    public class Team
    {
        public Team(int id, string name, int player1Id, int player2Id)
        {
            Id = id;
            Name = name;
            Player1Id = player1Id;
            Player2Id = player2Id;
        }

        public int Id { get; }
        public string Name { get; }
        public int Player1Id { get; }
        public int Player2Id { get; }
        public int[] PlayerIds => new[] { Player1Id, Player2Id };
    }
}
