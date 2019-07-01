namespace OfficeFoosball.DAL.Entities
{
    public class Player : Entity
    {
        public Player() : base()
        {
        }

        public Player(string name)
        {
            Nick = name;
        }

        public Player(int id, string name) : base(id)
        {
            Nick = name;
        }

        public string Nick { get; set; }
    }
}
