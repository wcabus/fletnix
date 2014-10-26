using System.Data.Entity.ModelConfiguration;
using Fletnix.Domain;

namespace Fletnix.EF.Mapping
{
    public class TvShowMap : EntityTypeConfiguration<TvShow>
    {
        public TvShowMap()
        {
            ToTable("TvShow");

            HasMany(t => t.Genres).WithMany().Map(m => m.ToTable("TvShowGenre").MapLeftKey("GenreId").MapRightKey("TvShowId"));
            HasMany(t => t.Seasons).WithRequired(s => s.TvShow).HasForeignKey(s => s.TvShowId).WillCascadeOnDelete();
        }
    }
}