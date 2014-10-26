using System.Data.Entity.ModelConfiguration;
using Fletnix.Domain;

namespace Fletnix.EF.Mapping
{
    public class CastMemberMap : EntityTypeConfiguration<CastMember>
    {
        public CastMemberMap()
        {
            ToTable("CastMember");

            HasRequired(c => c.Celebrity).WithMany().HasForeignKey(c => c.CelebrityId);
            HasRequired(c => c.MediaRole).WithMany().HasForeignKey(c => c.MediaRoleId);
        }
    }
}