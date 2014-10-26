using System.Data.Entity.ModelConfiguration;
using Fletnix.Domain;

namespace Fletnix.EF.Mapping
{
    public class SubscriptionOptionTemplateMap : EntityTypeConfiguration<SubscriptionOptionTemplate>
    {
        public SubscriptionOptionTemplateMap()
        {
            ToTable("SubscriptionOptionTemplate");
        }
    }
}