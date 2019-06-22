using System.Collections.Generic;
using OfficeFoosball.DAL;

namespace OfficeFoosball.Fakes
{
    public class PlayerRepository : IPlayerRepository
    {
        public IEnumerable<Player> Get() => new []
        {
            new Player{ Id = 1,     Name = "Janko" },
            new Player{ Id = 3,     Name = "Michal" },
            new Player{ Id = 4,     Name = "Kalousek" },
            new Player{ Id = 69,    Name = "Mr. Kroneisl" },
        };
    }
}
