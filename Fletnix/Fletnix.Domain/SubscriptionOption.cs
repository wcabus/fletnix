using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fletnix.Domain
{
    public class SubscriptionOption
    {
        [Key, ForeignKey("SubscriptionModel")]
        public int SubscriptionModelId { get; set; }

        [Key, ForeignKey("SubscriptionOptionTemplate")]
        public int SubscriptionOptionTemplateId { get; set; }

        [Required]
        public string Value { get; set; }

        public virtual SubscriptionModel SubscriptionModel { get; set; }
        public virtual SubscriptionOptionTemplate SubscriptionOptionTemplate { get; set; }
    }
}