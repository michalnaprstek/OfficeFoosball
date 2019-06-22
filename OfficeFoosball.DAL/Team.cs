namespace OfficeFoosball.DAL
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Player1Id { get; set; }
        public int Player2Id { get; set; }
        public int[] PlayerIds => new [] { Player1Id, Player2Id };
    }
}
