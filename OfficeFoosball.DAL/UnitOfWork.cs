using System.Threading.Tasks;
using OfficeFoosball.DAL.Repositories;

namespace OfficeFoosball.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FoosballContext _dbContext;

        private IPlayerRepository _playerRepository;
        private IMatchRepository _matchRepository;
        private ITeamRepository _teamRepository;

        public UnitOfWork(FoosballContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IPlayerRepository Players
            => _playerRepository ?? (_playerRepository = new PlayerRepository(_dbContext.Players));

        public IMatchRepository Matches =>
            _matchRepository ?? (_matchRepository = new MatchRepository(_dbContext.Matches));

        public ITeamRepository Teams =>
            _teamRepository ?? (_teamRepository = new TeamRepository(_dbContext.Teams));

        public ITokenRepository Tokens => new TokenRepository(_dbContext.RefreshTokens);

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}