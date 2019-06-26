using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OfficeFoosball.DAL;
using OfficeFoosball.DAL.Repositories;

namespace OfficeFoosball.Fakes
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FoosballContext _dbContext;

        public UnitOfWork(FoosballContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IPlayerRepository Players { get; } = new PlayerRepository();

        public IMatchRepository Matches { get; } = new MatchRepository();

        public ITeamRepository Teams { get; } = new TeamRepository();


        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public Task SaveAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
