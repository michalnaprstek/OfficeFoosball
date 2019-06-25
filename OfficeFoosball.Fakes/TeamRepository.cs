using System.Collections.Generic;
using OfficeFoosball.DAL.Repositories;
using OfficeFoosball.DAL.Entities;

namespace OfficeFoosball.Fakes
{
    public class TeamRepository : FakeRepository<Team>, ITeamRepository
    {
        public TeamRepository()
        {
            Data = new List<Team>
            {
                new Team { Id = 1,     Name = "Big Dicks",          Player1Id = 1,  Player2Id = 4 },
                new Team { Id = 2,     Name = "Dvě lamy na pastvě", Player1Id = 3,  Player2Id = 69},
                new Team { Id = 3,     Name = "void",               Player1Id = 3,  Player2Id = 1}
            };
        }
    }
}