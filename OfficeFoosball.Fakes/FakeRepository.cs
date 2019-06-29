using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OfficeFoosball.DAL.Repositories;
using OfficeFoosball.DAL.Entities;

namespace OfficeFoosball.Fakes
{
    public class FakeRepository<T> : IRepository<T> where T : Entity
    {
        protected IList<T> Data;

        public virtual Task<IReadOnlyList<T>> GetAsync()
            => Task.FromResult<IReadOnlyList<T>>(Data.ToList());

        public virtual Task<T> GetAsync(int id)
            => Task.FromResult(Data.Single(x => x.Id == id));
    }
}
