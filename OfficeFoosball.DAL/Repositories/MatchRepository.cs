using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OfficeFoosball.DAL.Entities;

namespace OfficeFoosball.DAL.Repositories
{
    public class MatchRepository : Repository<Match>, IMatchRepository
    {
        public MatchRepository(DbSet<Match> dbSet) : base(dbSet)
        {
        }

        public override async Task<IReadOnlyList<Match>> GetAsync()
        {
            return await DbSet.OrderByDescending(m => m.PlayedOn).ToListAsync();
        }

        public async Task<IReadOnlyList<Match>> GetAsync(DateTime date)
        {
            var dateWithoutTime = date.Date;
            return await DbSet
                .Where(m => m.PlayedOn >= dateWithoutTime && m.PlayedOn < dateWithoutTime.AddDays(1))
                .OrderByDescending(m => m.PlayedOn)
                .ToListAsync();
        }

        public async Task UpdateAsync(Match match)
        {
            if(match.Id != 0)
            {
                DbSet.Update(match);
            }
            else
            {
                match.PlayedOn = DateTime.Now;
                await DbSet.AddAsync(match);
            }
        }
    }
}
