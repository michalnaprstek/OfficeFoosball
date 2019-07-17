using OfficeFoosball.DAL.Repositories;
using OfficeFoosball.DAL.Entities;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OfficeFoosball.Fakes
{
    public class PlayerRepository : FakeRepository<Player>, IPlayerRepository
    {
        public PlayerRepository()
        {
            Data = new[]
            {
                new Player{ Id = 1,     Nick = "Janko" },
                new Player{ Id = 3,     Nick = "Michal" },
                new Player{ Id = 4,     Nick = "Kalousek" },
                new Player{ Id = 69,    Nick = "Mr. Kroneisl" },
            };
        }

        public Player CreatePlayer(Player player)
        {
            throw new System.NotImplementedException();
        }
        public Task<IReadOnlyList<Player>> GetAsync(IEnumerable<int> playerIds)
            => Task.FromResult<IReadOnlyList<Player>>(Data.Where(p => playerIds.Contains(p.Id)).ToArray());
    }
}
