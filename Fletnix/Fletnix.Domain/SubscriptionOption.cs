using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fletnix.Domain
{
    public class SubscriptionOption
    {
        [Key, Column(Order = 1)]
        public int SubscriptionModelId { get; set; }

        [Key, Column(Order = 2)]
        public int SubscriptionOptionTemplateId { get; set; }

        [Required, StringLength(128)]
        public string Value { get; set; }

        public virtual SubscriptionModel SubscriptionModel { get; set; }
        public virtual SubscriptionOptionTemplate SubscriptionOptionTemplate { get; set; }
    }
}