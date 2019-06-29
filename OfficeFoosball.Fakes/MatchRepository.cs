using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OfficeFoosball.DAL.Repositories;
using OfficeFoosball.DAL.Entities;

namespace OfficeFoosball.Fakes
{
    public class MatchRepository : FakeRepository<Match>, IMatchRepository
    {

        public MatchRepository()
        {
            Data = new List<Match>
            {
                new Match{ Id = 1, YellowTeamId = 1, YellowTeamScore = 10, RedTeamId = 2, RedTeamScore = 8, Note = "Test match",    PlayedOn = DateTime.Now.AddDays(-1) },
                new Match{ Id = 2, YellowTeamId = 1, YellowTeamScore = 8, RedTeamId = 2, RedTeamScore = 10, Note = "Test match 2",  PlayedOn = DateTime.Now.AddDays(-1) },
                new Match{ Id = 3, YellowTeamId = 1, YellowTeamScore = 8, RedTeamId = 2, RedTeamScore = 10, Note = "Test match 2",  PlayedOn = DateTime.Now.AddDays(-1) },
                new Match{ Id = 4, YellowTeamId = 1, YellowTeamScore = 8, RedTeamId = 2, RedTeamScore = 10, Note = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Etiam neque. Mauris dolor felis, sagittis at, luctus sed, aliquam non, tellus. Donec vitae arcu. Integer malesuada. Vestibulum fermentum tortor id mi. Fusce nibh. Aliquam erat volutpat. Etiam posuere lacus quis dolor. Integer rutrum, orci vestibulum ullamcorper ultricies, lacus quam ultricies odio, vitae placerat pede sem sit amet enim. Maecenas lorem. Vivamus ac leo pretium faucibus.",  PlayedOn = DateTime.Now.AddDays(-1) },
                new Match{ Id = 5, YellowTeamId = 1, YellowTeamScore = 8, RedTeamId = 2, RedTeamScore = 10, Note = "Test match 2",  PlayedOn = DateTime.Now.AddDays(-1) },
                new Match{ Id = 6, YellowTeamId = 1, YellowTeamScore = 8, RedTeamId = 2, RedTeamScore = 10, Note = "Test match 2",  PlayedOn = DateTime.Now.AddDays(-1) },
                new Match{ Id = 7, YellowTeamId = 1, YellowTeamScore = 8, RedTeamId = 2, RedTeamScore = 10, Note = "Test match 2",  PlayedOn = DateTime.Now.AddDays(-1) },
                new Match{ Id = 8, YellowTeamId = 1, YellowTeamScore = 8, RedTeamId = 2, RedTeamScore = 10, Note = "Test match 2",  PlayedOn = DateTime.Now.AddDays(-1) },
                new Match{ Id = 9, YellowTeamId = 1, YellowTeamScore = 8, RedTeamId = 2, RedTeamScore = 10, Note = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Etiam neque. Mauris dolor felis, sagittis at, luctus sed, aliquam non, tellus. Donec vitae arcu. Integer malesuada. Vestibulum fermentum tortor id mi. Fusce nibh. Aliquam erat volutpat. Etiam posuere lacus quis dolor. Integer rutrum, orci vestibulum ullamcorper ultricies, lacus quam ultricies odio, vitae placerat pede sem sit amet enim. Maecenas lorem. Vivamus ac leo pretium faucibus.",  PlayedOn = DateTime.Now.AddDays(-1) },
            };
        }
        public Task UpdateAsync(Match match)
        {
            if (match.Id != 0)
            {
                var m = Data.SingleOrDefault(x => x.Id == match.Id);
                Data.Remove(m);
            }
            else
            {
                match.Id = Data.Max(x => x.Id) + 1;
                match.PlayedOn = DateTime.Now;
            }
            Data.Add(match);
            return Task.CompletedTask;
        }
    }
}
