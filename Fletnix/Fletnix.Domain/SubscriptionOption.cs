using System.ComponentModel.DataAnnotations;

namespace Fletnix.Domain
{
    public class SubscriptionOption
    {
        [Required, StringLength(128)]
        public string Value { get; set; }

        public virtual SubscriptionModel SubscriptionModel { get; set; }
        public virtual SubscriptionOptionTemplate SubscriptionOptionTemplate { get; set; }
    }
}