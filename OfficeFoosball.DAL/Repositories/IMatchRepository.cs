using System.Threading.Tasks;
using OfficeFoosball.DAL.Entities;

namespace OfficeFoosball.DAL.Repositories
{
    public interface IMatchRepository : IRepository<Match>
    {
        Task UpdateAsync(Match match);
    }
}
