
using Domain.Entites;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace League_Master.Infrastructure
{
    public class LeagueMasterDbContext : DbContext
    {
        public LeagueMasterDbContext(DbContextOptions<LeagueMasterDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LeagueMasterDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<Round> Rounds { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Standing> Standings { get; set; }
        public DbSet<PlayerTeam> PlayerTeams { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<SeasonLeague> SeasonLeagues { get; set; }

    }
}
