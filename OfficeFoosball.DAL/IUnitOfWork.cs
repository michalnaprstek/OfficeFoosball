using System.Threading.Tasks;
using OfficeFoosball.DAL.Repositories;

namespace OfficeFoosball.DAL
{
    public interface IUnitOfWork
    {
        IPlayerRepository Players { get; }
        IMatchRepository Matches { get; }
        ITeamRepository Teams { get; }
        ITokenRepository Tokens { get; }
        Task SaveAsync();
    }
}
