using System.Collections.Generic;
using System.Linq;
using OfficeFoosball.DAL;

namespace OfficeFoosball.Fakes
{
    public class MatchRepository : IMatchRepository
    {
        private readonly IList<Match> _matches = new List<Match>
        {
            new Match{ Id = 1, YellowTeamId = 1, YellowTeamScore = 10, RedTeamId = 2, RedTeamScore = 8, Note = "Test match" },
            new Match{ Id = 2, YellowTeamId = 1, YellowTeamScore = 8, RedTeamId = 2, RedTeamScore = 10, Note = "Test match 2" },
        };


        public IEnumerable<Match> Get()
            => _matches;

        public Match Get(int id) 
            => _matches.FirstOrDefault(x => x.Id == id);

        public void Update(Match match)
        {
            if(match.Id != 0)
            {
                var m = _matches.SingleOrDefault(x => x.Id == match.Id);
                _matches.Remove(m);
            }
            _matches.Add(match);
        }
    }
}
