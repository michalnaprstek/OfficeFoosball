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
                new Player { Nick = "Janko" },
                new Player { Nick = "Michal" },
                new Player { Nick = "Kalousek" },
                new Player { Nick = "Mr. Kroneisl" },
            });

            _dbContext.Teams.AddRange(new[]
            {
                new Team { TeamName = "Big Dicks",          Player1 = 1,  Player2 = 3 },
                new Team { TeamName = "Dvě lamy na pastvě", Player1 = 2,  Player2 = 4},
                new Team { TeamName = "void",               Player1 = 1,  Player2 = 2}
            });

            _dbContext.Matches.AddRange(new[]
            {
                new Match{  TeamYellow = 1, TeamYellowScore = 10, TeamRed = 2, TeamRedScore = 8, Note = "Test match",    PlayedOn = DateTime.Now },
                new Match{  TeamYellow = 1, TeamYellowScore = 8, TeamRed = 2, TeamRedScore = 10, Note = "Test match 2",  PlayedOn = DateTime.Now.AddDays(-1) },
                new Match{  TeamYellow = 1, TeamYellowScore = 8, TeamRed = 2, TeamRedScore = 10, Note = "Test match 2",  PlayedOn = DateTime.Now },
                new Match{  TeamYellow = 1, TeamYellowScore = 8, TeamRed = 2, TeamRedScore = 10, Note = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Etiam neque. Mauris dolor felis, sagittis at, luctus sed, aliquam non, tellus. Donec vitae arcu. Integer malesuada. Vestibulum fermentum tortor id mi. Fusce nibh. Aliquam erat volutpat. Etiam posuere lacus quis dolor. Integer rutrum, orci vestibulum ullamcorper ultricies, lacus quam ultricies odio, vitae placerat pede sem sit amet enim. Maecenas lorem. Vivamus ac leo pretium faucibus.",  PlayedOn = DateTime.Now.AddDays(-1) },
                new Match{  TeamYellow = 1, TeamYellowScore = 8, TeamRed = 2, TeamRedScore = 10, Note = "Test match 2",  PlayedOn = DateTime.Now.AddDays(-1) },
                new Match{  TeamYellow = 1, TeamYellowScore = 8, TeamRed = 2, TeamRedScore = 10, Note = "Test match 2",  PlayedOn = DateTime.Now },
                new Match{  TeamYellow = 1, TeamYellowScore = 8, TeamRed = 2, TeamRedScore = 10, Note = "Test match 2",  PlayedOn = DateTime.Now.AddDays(-1) },
                new Match{  TeamYellow = 1, TeamYellowScore = 8, TeamRed = 2, TeamRedScore = 10, Note = "Test match 2",  PlayedOn = DateTime.Now },
                new Match{  TeamYellow = 1, TeamYellowScore = 8, TeamRed = 2, TeamRedScore = 10, Note = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Etiam neque. Mauris dolor felis, sagittis at, luctus sed, aliquam non, tellus. Donec vitae arcu. Integer malesuada. Vestibulum fermentum tortor id mi. Fusce nibh. Aliquam erat volutpat. Etiam posuere lacus quis dolor. Integer rutrum, orci vestibulum ullamcorper ultricies, lacus quam ultricies odio, vitae placerat pede sem sit amet enim. Maecenas lorem. Vivamus ac leo pretium faucibus.",  PlayedOn = DateTime.Now.AddDays(-1) },
            });

            _dbContext.SaveChanges();
        }
    }
}
