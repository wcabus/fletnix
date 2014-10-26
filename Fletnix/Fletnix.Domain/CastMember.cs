using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fletnix.Domain
{
    public class CastMember
    {
        [Key, Column(Order = 1)]
        public int MediaStreamId { get; set; }
        
        [Key, Column(Order = 2)]
        public int CelebrityId { get; set; }

        [Key, Column(Order = 3)]
        public int MediaRoleId { get; set; }

        public virtual MediaStream MediaStream { get; set; }
        public virtual Celebrity Celebrity { get; set; }
        public virtual MediaRole MediaRole { get; set; }
    }
}