
using OfficeFoosball.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OfficeFoosball.DAL.Repositories
{
    public interface IPlayerRepository : IRepository<Player>
    {
        Player CreatePlayer(Player player);
        Task<IReadOnlyList<Player>> GetAsync(IEnumerable<int> playerIds);
    }
}
