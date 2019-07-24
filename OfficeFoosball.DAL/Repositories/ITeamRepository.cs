
using OfficeFoosball.DAL.Entities;

namespace OfficeFoosball.DAL.Repositories
{
    public interface ITeamRepository : IRepository<Team>
    {
        Team CreateTeam(Team team);
    }
}
