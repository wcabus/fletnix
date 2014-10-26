using System.Data.Entity.ModelConfiguration;
using Fletnix.Domain;

namespace Fletnix.EF.Mapping
{
    public class ShowSeasonMap : EntityTypeConfiguration<ShowSeason>
    {
        public ShowSeasonMap()
        {
            ToTable("ShowSeason");

            HasMany(s => s.Episodes).
                WithOptional(m => m.ShowSeason).
                Map(m => m.MapKey("TvShowId", "Season"));
        }
    }
}