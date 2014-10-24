using System.Data.Entity;
using Fletnix.Domain;

namespace Fletnix.EF
{
    public class FletnixDbContext : DbContext
    {
        public FletnixDbContext() : base("FletnixDB")
        {
            //Disable lazy loading and proxy creation
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;

            //Database initialization
            Database.SetInitializer(new DbInitializer());
        }

        public DbSet<User> Users { get; set; }

        public DbSet<SubscriptionOptionTemplate> SubscriptionOptionTemplates { get; set; }

        public DbSet<SubscriptionModel> SubscriptionModels { get; set; }

        public DbSet<SubscriptionOption> SubscriptionOptions { get; set; }

        public DbSet<Subscription> Subscriptions { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<MediaRole> MediaRoles { get; set; }

        public DbSet<Celebrity> Celibrities { get; set; }

        public DbSet<CastMember> CastMembers { get; set; }

        public DbSet<TvShow> TvShows { get; set; }
        
        public DbSet<ShowSeason> ShowSeasons { get; set; }

        public DbSet<MediaStream> MediaStreams { get; set; }
    }
}
