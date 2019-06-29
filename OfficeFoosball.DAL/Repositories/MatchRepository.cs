using System;
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

        public async Task UpdateAsync(Match match)
        {
            if(match.Id != 0)
            {
                DbSet.Update(match);
            }
            else
            {
                match.Id = (await DbSet.MaxAsync(x => x.Id))+1;
                match.PlayedOn = DateTime.Now;
                await DbSet.AddAsync(match);
            }
        }
    }
}
