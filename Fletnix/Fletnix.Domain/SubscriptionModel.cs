using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fletnix.Domain
{
    public class SubscriptionModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, StringLength(32)]
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<SubscriptionOption> Options { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}