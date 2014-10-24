using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fletnix.Domain
{
    public class CastMember
    {
        [Key, ForeignKey("MediaStream")]
        public int MediaStreamId { get; set; }

        [Key, ForeignKey("Celebrity")]
        public int CelebrityId { get; set; }

        public virtual ICollection<MediaRole> Roles { get; set; }

        public virtual MediaStream MediaStream { get; set; }
        public virtual Celebrity Celebrity { get; set; }
    }
}