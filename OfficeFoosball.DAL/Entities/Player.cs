namespace OfficeFoosball.DAL.Entities
{
    public class Player : Entity
    {
        public Player() : base()
        {
        }

        public Player(string name)
        {
            Name = name;
        }

        public Player(int id, string name) : base(id)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
