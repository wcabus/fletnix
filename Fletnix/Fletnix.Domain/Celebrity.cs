using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fletnix.Domain
{
    public class Celebrity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, StringLength(128)]
        public string FirstName { get; set; }
        
        [Required, StringLength(128)]
        public string LastName { get; set; }

        [StringLength(16)]
        public string ImdbId { get; set; }

        [StringLength(512)]
        public string ImageUri { get; set; }
    }
}