using System.Data.Entity.ModelConfiguration;
using Fletnix.Domain;

namespace Fletnix.EF.Mapping
{
    public class SubscriptionMap : EntityTypeConfiguration<Subscription>
    {
        public SubscriptionMap()
        {
            ToTable("Subscription");

            HasRequired(s => s.SubscriptionModel).
                WithMany().
                HasForeignKey(s => s.SubscriptionModelId);

            // This is bad... You can't specify HasRequired.WithOptional.HasForeignKey, but only .Map at the end which doesn't work in this case.
            HasRequired(s => s.User).
                WithMany().
                HasForeignKey(s => s.UserId);

        }
    }
}