using System.Collections.Generic;
using System.Threading.Tasks;
using OfficeFoosball.DAL.Entities;

namespace OfficeFoosball.DAL.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        Task<IReadOnlyList<T>> GetAsync();
        Task<T> GetAsync(int id);
    }
}