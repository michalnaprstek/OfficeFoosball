using System.Collections.Generic;

namespace OfficeFoosball.DAL
{
    public interface IPlayerRepository
    {
        IEnumerable<Player> Get();
    }
}
