using System.Collections.Generic;
using System.Linq;
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

        public async Task<IReadOnlyList<Player>> GetAsync(IEnumerable<int> playerIds) 
            => await DbSet.Where(p => playerIds.Contains(p.Id)).ToListAsync();
    }
}
