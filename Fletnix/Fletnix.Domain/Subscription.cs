using System;

namespace Fletnix.Domain
{
    public class Subscription
    {
        public DateTime SubscriptionStartDate { get; set; }

        public bool IsActive { get; set; }

        public virtual User User { get; set; }

        public virtual SubscriptionModel SubscriptionModel { get; set; }
    }
}