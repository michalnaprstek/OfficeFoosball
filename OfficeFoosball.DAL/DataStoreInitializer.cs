using OfficeFoosball.DAL.Entities;
using System;

namespace OfficeFoosball.DAL
{
    public class DataStoreInitializer : IDataStoreInitializer
    {
        private readonly FoosballContext _dbContext;

        public DataStoreInitializer(FoosballContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Init()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();

            _dbContext.Players.AddRange(new[]
            {
                new Player { Id = 1, Name = "Janko" },
                new Player { Id = 3, Name = "Michal" },
                new Player { Id = 4, Name = "Kalousek" },
                new Player { Id = 69, Name = "Mr. Kroneisl" },
            });

            _dbContext.Teams.AddRange(new[]
            {
                new Team { Id = 1,     Name = "Big Dicks",          Player1Id = 1,  Player2Id = 4 },
                new Team { Id = 2,     Name = "Dvě lamy na pastvě", Player1Id = 3,  Player2Id = 69},
                new Team { Id = 3,     Name = "void",               Player1Id = 3,  Player2Id = 1}
            });

            _dbContext.Matches.AddRange(new[]
            {
                new Match{ Id = 1, YellowTeamId = 1, YellowTeamScore = 10, RedTeamId = 2, RedTeamScore = 8, Note = "Test match",    PlayedOn = DateTime.Now.AddDays(-1) },
                new Match{ Id = 2, YellowTeamId = 1, YellowTeamScore = 8, RedTeamId = 2, RedTeamScore = 10, Note = "Test match 2",  PlayedOn = DateTime.Now.AddDays(-1) },
                new Match{ Id = 3, YellowTeamId = 1, YellowTeamScore = 8, RedTeamId = 2, RedTeamScore = 10, Note = "Test match 2",  PlayedOn = DateTime.Now.AddDays(-1) },
                new Match{ Id = 4, YellowTeamId = 1, YellowTeamScore = 8, RedTeamId = 2, RedTeamScore = 10, Note = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Etiam neque. Mauris dolor felis, sagittis at, luctus sed, aliquam non, tellus. Donec vitae arcu. Integer malesuada. Vestibulum fermentum tortor id mi. Fusce nibh. Aliquam erat volutpat. Etiam posuere lacus quis dolor. Integer rutrum, orci vestibulum ullamcorper ultricies, lacus quam ultricies odio, vitae placerat pede sem sit amet enim. Maecenas lorem. Vivamus ac leo pretium faucibus.",  PlayedOn = DateTime.Now.AddDays(-1) },
                new Match{ Id = 5, YellowTeamId = 1, YellowTeamScore = 8, RedTeamId = 2, RedTeamScore = 10, Note = "Test match 2",  PlayedOn = DateTime.Now.AddDays(-1) },
                new Match{ Id = 6, YellowTeamId = 1, YellowTeamScore = 8, RedTeamId = 2, RedTeamScore = 10, Note = "Test match 2",  PlayedOn = DateTime.Now.AddDays(-1) },
                new Match{ Id = 7, YellowTeamId = 1, YellowTeamScore = 8, RedTeamId = 2, RedTeamScore = 10, Note = "Test match 2",  PlayedOn = DateTime.Now.AddDays(-1) },
                new Match{ Id = 8, YellowTeamId = 1, YellowTeamScore = 8, RedTeamId = 2, RedTeamScore = 10, Note = "Test match 2",  PlayedOn = DateTime.Now.AddDays(-1) },
                new Match{ Id = 9, YellowTeamId = 1, YellowTeamScore = 8, RedTeamId = 2, RedTeamScore = 10, Note = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Etiam neque. Mauris dolor felis, sagittis at, luctus sed, aliquam non, tellus. Donec vitae arcu. Integer malesuada. Vestibulum fermentum tortor id mi. Fusce nibh. Aliquam erat volutpat. Etiam posuere lacus quis dolor. Integer rutrum, orci vestibulum ullamcorper ultricies, lacus quam ultricies odio, vitae placerat pede sem sit amet enim. Maecenas lorem. Vivamus ac leo pretium faucibus.",  PlayedOn = DateTime.Now.AddDays(-1) },
            });

            _dbContext.SaveChanges();
        }
    }
}
