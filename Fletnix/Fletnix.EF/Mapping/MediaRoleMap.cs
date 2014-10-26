using System.Data.Entity.ModelConfiguration;
using Fletnix.Domain;

namespace Fletnix.EF.Mapping
{
    public class MediaRoleMap : EntityTypeConfiguration<MediaRole>
    {
        public MediaRoleMap()
        {
            ToTable("MediaRole");
        }
    }
}