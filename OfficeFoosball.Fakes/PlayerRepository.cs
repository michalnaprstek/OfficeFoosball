using OfficeFoosball.DAL.Repositories;
using OfficeFoosball.DAL.Entities;

namespace OfficeFoosball.Fakes
{
    public class PlayerRepository : FakeRepository<Player>, IPlayerRepository
    {
        public PlayerRepository()
        {
            Data = new[]
            {
                new Player{ Id = 1,     Name = "Janko" },
                new Player{ Id = 3,     Name = "Michal" },
                new Player{ Id = 4,     Name = "Kalousek" },
                new Player{ Id = 69,    Name = "Mr. Kroneisl" },
            };
        }

        public Player CreatePlayer(Player player)
        {
            throw new System.NotImplementedException();
        }
    }
}
