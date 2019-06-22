using System.Collections.Generic;

namespace OfficeFoosball.DAL
{
    public interface IMatchRepository
    {
        IEnumerable<Match> Get();

        Match Get(int id);

        void Update(Match match);
    }
}
