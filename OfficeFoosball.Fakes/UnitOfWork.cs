using OfficeFoosball.DAL;

namespace OfficeFoosball.Fakes
{
    public class UnitOfWork : IUnitOfWork
    {

        public IPlayerRepository Players { get; } = new PlayerRepository();

        public IMatchRepository Matches { get; } = new MatchRepository();

        public ITeamRepository Teams { get; } = new TeamRepository();
    }
}
