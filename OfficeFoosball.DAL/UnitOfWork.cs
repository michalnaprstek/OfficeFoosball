using System.Threading.Tasks;
using OfficeFoosball.DAL.Repositories;

namespace OfficeFoosball.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FoosballContext _dbContext;

        public UnitOfWork(FoosballContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public IPlayerRepository Players => new PlayerRepository(_dbContext.Players);

        public IMatchRepository Matches => new MatchRepository(_dbContext.Matches);

        public ITeamRepository Teams => new TeamRepository(_dbContext.Teams);

        public void Save()
        {
            _dbContext.SaveChangesAsync();
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}