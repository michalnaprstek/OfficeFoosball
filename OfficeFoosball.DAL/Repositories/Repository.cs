using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OfficeFoosball.DAL.Entities;

namespace OfficeFoosball.DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly DbSet<T> DbSet;

        public Repository(DbSet<T> dbSet)
        {
            DbSet = dbSet;
        }

        public Task<T> GetAsync(int id)
            => DbSet.FindAsync(id);


        public async Task<IReadOnlyList<T>> GetAsync()
            => await DbSet.ToListAsync();
    }
}
