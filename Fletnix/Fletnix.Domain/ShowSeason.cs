using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fletnix.Domain
{
    public class ShowSeason
    {
        [Key]
        public int TvShowId { get; set; }

        [Key, Required, Range(1, 999)]
        public int Season { get; set; }

        public virtual TvShow TvShow { get; set; }

        public virtual ICollection<MediaStream> Episodes { get; set; }
    }
}