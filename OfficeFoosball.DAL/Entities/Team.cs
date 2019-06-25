namespace OfficeFoosball.DAL.Entities
{
    public class Team : Entity
    {
        public string Name { get; set; }
        public int Player1Id { get; set; }
        public int Player2Id { get; set; }
        public int[] PlayerIds => new [] { Player1Id, Player2Id };
    }
}
