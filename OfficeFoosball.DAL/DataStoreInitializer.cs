using OfficeFoosball.DAL.Entities;
using System;
using System.Linq;

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
            //_dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();

            if(_dbContext.Players.Any())
                return;

            _dbContext.Players.AddRange(new[]
            {
                new Player { Id = 1, Nick = "Janko" },
                new Player { Id = 3, Nick = "Michal" },
                new Player { Id = 4, Nick = "Kalousek" },
                new Player { Id = 69, Nick = "Mr. Kroneisl" },
            });

            _dbContext.Teams.AddRange(new[]
            {
                new Team { Id = 1,     TeamName = "Big Dicks",          Player1 = 1,  Player2 = 4 },
                new Team { Id = 2,     TeamName = "Dvě lamy na pastvě", Player1 = 3,  Player2 = 69},
                new Team { Id = 3,     TeamName = "void",               Player1 = 3,  Player2 = 1}
            });

            _dbContext.Matches.AddRange(new[]
            {
                new Match{ Id = 1, TeamYellow = 1, TeamYellowScore = 10, TeamRed = 2, TeamRedScore = 8, Note = "Test match",    PlayedOn = DateTime.Now },
                new Match{ Id = 2, TeamYellow = 1, TeamYellowScore = 8, TeamRed = 2, TeamRedScore = 10, Note = "Test match 2",  PlayedOn = DateTime.Now.AddDays(-1) },
                new Match{ Id = 3, TeamYellow = 1, TeamYellowScore = 8, TeamRed = 2, TeamRedScore = 10, Note = "Test match 2",  PlayedOn = DateTime.Now },
                new Match{ Id = 4, TeamYellow = 1, TeamYellowScore = 8, TeamRed = 2, TeamRedScore = 10, Note = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Etiam neque. Mauris dolor felis, sagittis at, luctus sed, aliquam non, tellus. Donec vitae arcu. Integer malesuada. Vestibulum fermentum tortor id mi. Fusce nibh. Aliquam erat volutpat. Etiam posuere lacus quis dolor. Integer rutrum, orci vestibulum ullamcorper ultricies, lacus quam ultricies odio, vitae placerat pede sem sit amet enim. Maecenas lorem. Vivamus ac leo pretium faucibus.",  PlayedOn = DateTime.Now.AddDays(-1) },
                new Match{ Id = 5, TeamYellow = 1, TeamYellowScore = 8, TeamRed = 2, TeamRedScore = 10, Note = "Test match 2",  PlayedOn = DateTime.Now.AddDays(-1) },
                new Match{ Id = 6, TeamYellow = 1, TeamYellowScore = 8, TeamRed = 2, TeamRedScore = 10, Note = "Test match 2",  PlayedOn = DateTime.Now },
                new Match{ Id = 7, TeamYellow = 1, TeamYellowScore = 8, TeamRed = 2, TeamRedScore = 10, Note = "Test match 2",  PlayedOn = DateTime.Now.AddDays(-1) },
                new Match{ Id = 8, TeamYellow = 1, TeamYellowScore = 8, TeamRed = 2, TeamRedScore = 10, Note = "Test match 2",  PlayedOn = DateTime.Now },
                new Match{ Id = 9, TeamYellow = 1, TeamYellowScore = 8, TeamRed = 2, TeamRedScore = 10, Note = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Etiam neque. Mauris dolor felis, sagittis at, luctus sed, aliquam non, tellus. Donec vitae arcu. Integer malesuada. Vestibulum fermentum tortor id mi. Fusce nibh. Aliquam erat volutpat. Etiam posuere lacus quis dolor. Integer rutrum, orci vestibulum ullamcorper ultricies, lacus quam ultricies odio, vitae placerat pede sem sit amet enim. Maecenas lorem. Vivamus ac leo pretium faucibus.",  PlayedOn = DateTime.Now.AddDays(-1) },
            });

            _dbContext.SaveChanges();
        }
    }
}
