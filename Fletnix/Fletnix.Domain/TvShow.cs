using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fletnix.Domain
{
    public class TvShow
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, StringLength(256)]
        public string Title { get; set; }

        [StringLength(1024)]
        public string ImageUri { get; set; }

        public virtual ICollection<Genre> Genres { get; set; }
        public virtual ICollection<ShowSeason> Seasons { get; set; }
    }
}