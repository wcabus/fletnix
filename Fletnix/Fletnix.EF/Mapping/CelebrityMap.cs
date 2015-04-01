using System.Data.Entity.ModelConfiguration;
using Fletnix.Domain;

namespace Fletnix.EF.Mapping
{
    public class CelebrityMap : EntityTypeConfiguration<Celebrity>
    {
        public CelebrityMap()
        {
            ToTable("Celebrity");

            Property(c => c.ImdbId).IsUnicode(false);
            Property(c => c.ImageUri).IsUnicode(false);
        }
    }
}