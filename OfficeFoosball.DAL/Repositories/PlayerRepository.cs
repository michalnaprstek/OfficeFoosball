using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OfficeFoosball.DAL.Entities;

namespace OfficeFoosball.DAL.Repositories
{
    public class PlayerRepository : Repository<Player>, IPlayerRepository
    {
        public PlayerRepository(DbSet<Player> dbSet) : base(dbSet)
        {
        }

        public Player CreatePlayer(Player player)
        {
            DbSet.Add(player);
            return player;  
        }
    }
}
