
using Domain.Entites;
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

         //   modelBuilder.Entity<Role>().ToTable("Roles");

            base.OnModelCreating(modelBuilder);

            //// User-Role Relationship
            //modelBuilder.Entity<User>()
            //    .HasOne(u => u.Role)
            //    .WithMany(r => r.Users)
            //    .HasForeignKey(u => u.Role_ID)
            //    .OnDelete(DeleteBehavior.Restrict);

            //// Company-User Relationship
            //modelBuilder.Entity<User>()
            //    .HasOne(c => c.Company)
            //    .WithMany(u => u.Users)
            //    .HasForeignKey(c => c.User_ID)
            //    .OnDelete(DeleteBehavior.Restrict);

            //// League-Company Relationship
            //modelBuilder.Entity<League>()
            //    .HasOne(l => l.Company)
            //    .WithMany(c => c.Leagues)
            //    .HasForeignKey(l => l.Company_ID)
            //    .OnDelete(DeleteBehavior.Restrict);

            //// Round-League Relationship
            //modelBuilder.Entity<Round>()
            //    .HasOne(r => r.League)
            //    .WithMany(l => l.Rounds)
            //    .HasForeignKey(r => r.League_ID)
            //    .OnDelete(DeleteBehavior.Cascade);

            //// Team-League Relationship
            //modelBuilder.Entity<Team>()
            //    .HasOne(t => t.League)
            //    .WithMany(l => l.Teams)
            //    .HasForeignKey(t => t.League_ID)
            //    .OnDelete(DeleteBehavior.Restrict);

            //// Player-Team Relationship
            //modelBuilder.Entity<Player>()
            //    .HasOne(p => p.Team)
            //    .WithMany(t => t.Players)
            //    .HasForeignKey(p => p.Team_ID)
            //    .OnDelete(DeleteBehavior.Restrict);

            //// Match-Team Relationship (HomeTeam)
            //modelBuilder.Entity<Match>()
            //    .HasOne(m => m.HomeTeam)
            //    .WithMany(t => t.Matches)
            //    .HasForeignKey(m => m.HomeTeam_ID)
            //    .OnDelete(DeleteBehavior.Restrict);

            //// Match-Team Relationship (AwayTeam)
            //modelBuilder.Entity<Match>()
            //    .HasOne(m => m.AwayTeam)
            //    .WithMany(t => t.Matches)
            //    .HasForeignKey(m => m.AwayTeam_ID)
            //    .OnDelete(DeleteBehavior.Restrict);

            //// Standing-Team Relationship
            //modelBuilder.Entity<Standing>()
            //    .HasOne(s => s.Team)
            //    .WithOne(t => t.Standing)
            //    .HasForeignKey<Standing>(s => s.Team_ID)
            //    .OnDelete(DeleteBehavior.Cascade);

            //// Standing-League Relationship
            //modelBuilder.Entity<Standing>()
            //    .HasOne(s => s.League)
            //    .WithMany(l => l.Standings)
            //    .HasForeignKey(s => s.League_ID)
            //    .OnDelete(DeleteBehavior.Restrict);
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

    }
}
