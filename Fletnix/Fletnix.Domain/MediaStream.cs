using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fletnix.Domain
{
    public class MediaStream
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public Guid StreamId { get; set; }

        [EnumDataType(typeof(MediaStreamType))]
        public MediaStreamType MediaStreamTypeId { get; set; }

        public TimeSpan Length { get; set; }

        [Required, StringLength(256)]
        public string Title { get; set; }

        public string Synopsis { get; set; }

        [StringLength(1024)]
        public string ImageUri { get; set; }

        public virtual ICollection<Genre> Genres { get; set; }

        public virtual ICollection<CastMember> Cast { get; set; }

        public int? TvShowId { get; set; }
        public int? Season { get; set; }
        public virtual ShowSeason ShowSeason { get; set; }
    }
}