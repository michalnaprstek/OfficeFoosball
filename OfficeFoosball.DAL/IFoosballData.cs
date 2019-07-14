using Microsoft.EntityFrameworkCore;
using OfficeFoosball.DAL.Entities;

namespace OfficeFoosball.DAL
{
    public interface IFoosballDatabase
    {
        DbSet<Match> Matches { get; }
        DbSet<Player> Players { get; }
        DbSet<Team> Teams { get; }
    }
}