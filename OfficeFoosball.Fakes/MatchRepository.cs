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
                new Match{ Id = 1, TeamYellow = 1, TeamYellowScore = 10, TeamRed = 2, TeamRedScore = 8, Note = "Test match",    PlayedOn = DateTime.Now.AddDays(-1) },
                new Match{ Id = 2, TeamYellow = 1, TeamYellowScore = 8, TeamRed = 2, TeamRedScore = 10, Note = "Test match 2",  PlayedOn = DateTime.Now.AddDays(-1) },
                new Match{ Id = 3, TeamYellow = 1, TeamYellowScore = 8, TeamRed = 2, TeamRedScore = 10, Note = "Test match 2",  PlayedOn = DateTime.Now.AddDays(-1) },
                new Match{ Id = 4, TeamYellow = 1, TeamYellowScore = 8, TeamRed = 2, TeamRedScore = 10, Note = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Etiam neque. Mauris dolor felis, sagittis at, luctus sed, aliquam non, tellus. Donec vitae arcu. Integer malesuada. Vestibulum fermentum tortor id mi. Fusce nibh. Aliquam erat volutpat. Etiam posuere lacus quis dolor. Integer rutrum, orci vestibulum ullamcorper ultricies, lacus quam ultricies odio, vitae placerat pede sem sit amet enim. Maecenas lorem. Vivamus ac leo pretium faucibus.",  PlayedOn = DateTime.Now.AddDays(-1) },
                new Match{ Id = 5, TeamYellow = 1, TeamYellowScore = 8, TeamRed = 2, TeamRedScore = 10, Note = "Test match 2",  PlayedOn = DateTime.Now.AddDays(-1) },
                new Match{ Id = 6, TeamYellow = 1, TeamYellowScore = 8, TeamRed = 2, TeamRedScore = 10, Note = "Test match 2",  PlayedOn = DateTime.Now.AddDays(-1) },
                new Match{ Id = 7, TeamYellow = 1, TeamYellowScore = 8, TeamRed = 2, TeamRedScore = 10, Note = "Test match 2",  PlayedOn = DateTime.Now.AddDays(-1) },
                new Match{ Id = 8, TeamYellow = 1, TeamYellowScore = 8, TeamRed = 2, TeamRedScore = 10, Note = "Test match 2",  PlayedOn = DateTime.Now.AddDays(-1) },
                new Match{ Id = 9, TeamYellow = 1, TeamYellowScore = 8, TeamRed = 2, TeamRedScore = 10, Note = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Etiam neque. Mauris dolor felis, sagittis at, luctus sed, aliquam non, tellus. Donec vitae arcu. Integer malesuada. Vestibulum fermentum tortor id mi. Fusce nibh. Aliquam erat volutpat. Etiam posuere lacus quis dolor. Integer rutrum, orci vestibulum ullamcorper ultricies, lacus quam ultricies odio, vitae placerat pede sem sit amet enim. Maecenas lorem. Vivamus ac leo pretium faucibus.",  PlayedOn = DateTime.Now.AddDays(-1) },
            };
        }

        public Task<IReadOnlyList<Match>> GetAsync(DateTime date)
        {
            var dateWithoutTime = date.Date;
            return Task.FromResult<IReadOnlyList<Match>>(Data
                .Where(m => m.PlayedOn >= dateWithoutTime && m.PlayedOn < dateWithoutTime.AddDays(1))
                .OrderBy(m => m.PlayedOn).ToArray());
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
