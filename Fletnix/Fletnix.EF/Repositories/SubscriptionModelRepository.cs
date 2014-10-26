using Fletnix.Domain;

namespace Fletnix.EF.Repositories
{
    public class SubscriptionModelRepository : BaseRepository<SubscriptionModel>
    {
        public SubscriptionModelRepository(FletnixDbContext context) : base(context)
        {
            
        }
    }
}