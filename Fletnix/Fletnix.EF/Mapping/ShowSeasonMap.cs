using System.Data.Entity.ModelConfiguration;
using Fletnix.Domain;

namespace Fletnix.EF.Mapping
{
    public class ShowSeasonMap : EntityTypeConfiguration<ShowSeason>
    {
        public ShowSeasonMap()
        {
            ToTable("ShowSeason");
        }
    }
}