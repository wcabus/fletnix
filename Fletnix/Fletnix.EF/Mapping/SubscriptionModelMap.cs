using System.Data.Entity.ModelConfiguration;
using Fletnix.Domain;

namespace Fletnix.EF.Mapping
{
    public class SubscriptionModelMap : EntityTypeConfiguration<SubscriptionModel>
    {
        public SubscriptionModelMap()
        {
            ToTable("SubscriptionModel");

            HasMany(s => s.Options).
                WithRequired(o => o.SubscriptionModel).
                HasForeignKey(o => o.SubscriptionModelId).WillCascadeOnDelete();
        }
    }
}