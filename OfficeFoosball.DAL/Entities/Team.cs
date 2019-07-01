namespace OfficeFoosball.DAL.Entities
{
    public class Team : Entity
    {
        public string TeamName { get; set; }
        public int Player1 { get; set; }
        public int Player2 { get; set; }
        public int[] PlayerIds => new [] { Player1, Player2 };
    }
}
