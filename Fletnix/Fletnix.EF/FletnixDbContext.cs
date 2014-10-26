using System.Data.Entity;
using Fletnix.EF.Mapping;

namespace Fletnix.EF
{
    public class FletnixDbContext : DbContext
    {
        public FletnixDbContext() : base("FletnixDB")
        {
            //Disable lazy loading and proxy creation
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new GenreMap());
            modelBuilder.Configurations.Add(new MediaRoleMap());
            modelBuilder.Configurations.Add(new CelebrityMap());
            modelBuilder.Configurations.Add(new TvShowMap());
            modelBuilder.Configurations.Add(new ShowSeasonMap());
            modelBuilder.Configurations.Add(new MediaStreamMap());
            modelBuilder.Configurations.Add(new CastMemberMap());

            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new SubscriptionModelMap());
            modelBuilder.Configurations.Add(new SubscriptionOptionTemplateMap());
            modelBuilder.Configurations.Add(new SubscriptionOptionMap());
            modelBuilder.Configurations.Add(new SubscriptionMap());
        }
    }
}
