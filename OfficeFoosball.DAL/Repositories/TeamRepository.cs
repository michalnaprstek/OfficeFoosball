using Microsoft.EntityFrameworkCore;
using OfficeFoosball.DAL.Entities;
using System.Linq;

namespace OfficeFoosball.DAL.Repositories
{
    public class TeamRepository : Repository<Team>, ITeamRepository
    {
        public TeamRepository(DbSet<Team> dbSet) : base(dbSet)
        {
        }

        public Team CreateTeam(Team team)
        {
            DbSet.Add(team);
            return team;
        }
    }
}
