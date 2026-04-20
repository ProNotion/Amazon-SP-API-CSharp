using System.Runtime.Serialization;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Replenishment
{
    /// <summary>
    /// A set of replenishment metric values for a given time interval.
    /// </summary>
    public class ReplenishmentMetric
    {
        /// <summary>The number of units shipped to subscribers.</summary>
        [DataMember(Name = "shippedSubscriptionUnits", EmitDefaultValue = false)]
        public int? ShippedSubscriptionUnits { get; set; }

        /// <summary>The revenue generated from subscriptions.</summary>
        [DataMember(Name = "totalSubscriptionsRevenue", EmitDefaultValue = false)]
        public decimal? TotalSubscriptionsRevenue { get; set; }

        /// <summary>The number of active subscriptions at the end of the period.</summary>
        [DataMember(Name = "activeSubscriptions", EmitDefaultValue = false)]
        public int? ActiveSubscriptions { get; set; }

        /// <summary>The percentage of items not shipped due to being out of stock.</summary>
        [DataMember(Name = "notDeliveredDueToOOS", EmitDefaultValue = false)]
        public decimal? NotDeliveredDueToOOS { get; set; }

        /// <summary>The average revenue per subscriber versus non-subscriber.</summary>
        [DataMember(Name = "subscriberNonSubscriberAverageRevenue", EmitDefaultValue = false)]
        public decimal? SubscriberNonSubscriberAverageRevenue { get; set; }

        /// <summary>The revenue lost due to out-of-stock events.</summary>
        [DataMember(Name = "lostRevenueDueToOOS", EmitDefaultValue = false)]
        public decimal? LostRevenueDueToOOS { get; set; }

        /// <summary>The average reorders per subscriber versus non-subscriber.</summary>
        [DataMember(Name = "subscriberNonSubscriberAverageReorders", EmitDefaultValue = false)]
        public decimal? SubscriberNonSubscriberAverageReorders { get; set; }

        /// <summary>The percentage of revenue from ASINs with coupons out of total revenue.</summary>
        [DataMember(Name = "couponsRevenuePenetration", EmitDefaultValue = false)]
        public decimal? CouponsRevenuePenetration { get; set; }

        /// <summary>The revenue generated per delivery.</summary>
        [DataMember(Name = "revenueByDeliveries", EmitDefaultValue = false)]
        public decimal? RevenueByDeliveries { get; set; }

        /// <summary>The percentage of subscribers retained over the period.</summary>
        [DataMember(Name = "subscriberRetention", EmitDefaultValue = false)]
        public decimal? SubscriberRetention { get; set; }

        /// <summary>The percentage of revenue attributed to seller-funded promotions.</summary>
        [DataMember(Name = "revenuePenetrationBySellerFunding", EmitDefaultValue = false)]
        public decimal? RevenuePenetrationBySellerFunding { get; set; }

        /// <summary>The average revenue over the lifetime of a subscriber, segmented by customer type.</summary>
        [DataMember(Name = "subscriberLifetimeValueByCustomerSegment", EmitDefaultValue = false)]
        public decimal? SubscriberLifetimeValueByCustomerSegment { get; set; }

        /// <summary>The percentage of sign-ups attributed to seller-funded promotions.</summary>
        [DataMember(Name = "signupConversionBySellerFunding", EmitDefaultValue = false)]
        public decimal? SignupConversionBySellerFunding { get; set; }

        /// <summary>The percentage of total revenue that comes from subscription orders.</summary>
        [DataMember(Name = "revenuePenetration", EmitDefaultValue = false)]
        public decimal? RevenuePenetration { get; set; }

        /// <summary>The time interval for which the metrics apply.</summary>
        [DataMember(Name = "timeInterval", EmitDefaultValue = false)]
        public TimeInterval TimeInterval { get; set; }

        /// <summary>The currency code for revenue-related metrics.</summary>
        [DataMember(Name = "currencyCode", EmitDefaultValue = false)]
        public string CurrencyCode { get; set; }
    }
}
