using System.Collections.Generic;

namespace OfficeFoosball.DAL
{
    public interface ITeamRepository
    {
        IEnumerable<Team> Get();
        Team Get(int id);
    }
}
