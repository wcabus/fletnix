using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fletnix.Domain
{
    public class Subscription
    {
        [Key, ForeignKey("User")]
        public int UserId { get; set; }

        [Key, ForeignKey("SubscriptionModel")]
        public int SubscriptionModelId { get; set; }

        public DateTime SubscriptionStartDate { get; set; }

        public bool IsActive { get; set; }

        public virtual User User { get; set; }

        public virtual SubscriptionModel SubscriptionModel { get; set; }
    }
}