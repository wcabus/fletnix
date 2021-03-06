﻿using System.Data.Entity.ModelConfiguration;
using Fletnix.Domain;

namespace Fletnix.EF.Mapping
{
    public class SubscriptionMap : EntityTypeConfiguration<Subscription>
    {
        public SubscriptionMap()
        {
            ToTable("Subscription");

            HasRequired(s => s.SubscriptionModel).
                WithMany().
                Map(m => m.MapKey("SubscriptionModelId"));

            HasRequired(s => s.User).
                WithOptional(u => u.Subscription).
                Map(m => m.MapKey("UserId"));

        }
    }
}