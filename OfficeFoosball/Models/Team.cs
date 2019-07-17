namespace OfficeFoosball.Models
{
    public class Team
    {
        public Team(int id, string name, Player player1, Player player2)
        {
            Id = id;
            Name = name;
            Player1 = player1;
            Player2 = player2;
        }

        public int Id { get; }
        public string Name { get; }
        public Player Player1 { get; }
        public Player Player2 { get; }
        public int[] PlayerIds => new[] { Player1.Id, Player2.Id };
    }
}
