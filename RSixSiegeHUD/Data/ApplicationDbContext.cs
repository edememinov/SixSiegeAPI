using Microsoft.EntityFrameworkCore;
using RSixSiegeHUD.Models;

namespace RSixSiegeHUD.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
         : base(options)
        {
        }

        public DbSet<Death> Deaths { get; set; }
        public DbSet<Kill> Kills { get; set; }
        public DbSet<GameInfo> GameInfos { get; set; }
        public DbSet<LocalPlayer> LocalPlayers { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<MatchOutcome> MatchOutcomes { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Round> Rounds { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<RoundOutcome> RoundOutcomes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

    }
}
