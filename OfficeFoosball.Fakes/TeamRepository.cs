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
                new Team { Id = 1,     TeamName = "Big Dicks",          Player1 = 1,  Player2 = 4 },
                new Team { Id = 2,     TeamName = "Dvě lamy na pastvě", Player1 = 3,  Player2 = 69},
                new Team { Id = 3,     TeamName = "void",               Player1 = 3,  Player2 = 1}
            };
        }
    }
}