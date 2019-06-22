using System.Collections.Generic;
using System.Linq;
using OfficeFoosball.DAL;

namespace OfficeFoosball.Fakes
{
    public class TeamRepository : ITeamRepository
    {
        private readonly IList<Team> _teams = new List<Team>
        {
            new Team { Id = 1,     Name = "Big Dicks",          Player1Id = 1,  Player2Id = 4 },
            new Team { Id = 2,     Name = "Dvě lamy na pastvě", Player1Id = 3,  Player2Id = 69},
            new Team { Id = 3,     Name = "void",               Player1Id = 3,  Player2Id = 1}
        };

        public IEnumerable<Team> Get() 
            => _teams;

        public Team Get(int id) 
            => _teams.SingleOrDefault(x => x.Id == id);
    }
}