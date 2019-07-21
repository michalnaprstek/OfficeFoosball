using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OfficeFoosball.DAL.Entities;

namespace OfficeFoosball.DAL
{
    public class FoosballContext : IdentityDbContext<User>, IFoosballDatabase
    {
        public FoosballContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Match> Matches { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Player>()
                .ToTable("Player")
                .Property(p => p.Id);

            modelBuilder.Entity<Team>()
                .ToTable("Team")
                .Property(p => p.Id);

            modelBuilder.Entity<Match>()
                .ToTable("Match")
                .Property(p => p.Id);
        }
    }
}
