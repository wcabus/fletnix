using System.Data.Entity.ModelConfiguration;
using Fletnix.Domain;

namespace Fletnix.EF.Mapping
{
    public class CastMemberMap : EntityTypeConfiguration<CastMember>
    {
        public CastMemberMap()
        {
            ToTable("CastMember");

            HasRequired(c => c.Celebrity).WithMany().Map(m => m.MapKey("CelebrityId"));
            HasRequired(c => c.MediaRole).WithMany().Map(m => m.MapKey("MediaRoleId"));
        }
    }
}