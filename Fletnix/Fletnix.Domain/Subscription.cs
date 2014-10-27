using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fletnix.Domain
{
    public class Subscription
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime SubscriptionStartDate { get; set; }

        public bool IsActive { get; set; }

        public virtual User User { get; set; }

        public virtual SubscriptionModel SubscriptionModel { get; set; }
    }
}