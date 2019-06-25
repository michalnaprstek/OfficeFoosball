
using OfficeFoosball.DAL.Entities;
using System.Threading.Tasks;

namespace OfficeFoosball.DAL.Repositories
{
    public interface IPlayerRepository : IRepository<Player>
    {
        Player CreatePlayer(Player player);
    }
}
