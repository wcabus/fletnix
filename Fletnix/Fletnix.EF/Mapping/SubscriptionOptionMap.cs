using System.Data.Entity.ModelConfiguration;
using Fletnix.Domain;

namespace Fletnix.EF.Mapping
{
    public class SubscriptionOptionMap : EntityTypeConfiguration<SubscriptionOption>
    {
        public SubscriptionOptionMap()
        {
            ToTable("SubscriptionOption");

            HasRequired(o => o.SubscriptionOptionTemplate).
                WithMany().
                HasForeignKey(o => o.SubscriptionOptionTemplateId);
        }
    }
}