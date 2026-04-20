using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Replenishment
{
    /// <summary>
    /// Represents various metrics related to subscription services and revenue generation.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Metric
    {
        /// <summary>The number of units shipped to subscribers over a period of time.</summary>
        SHIPPED_SUBSCRIPTION_UNITS,

        /// <summary>The revenue generated from subscriptions over a period of time.</summary>
        TOTAL_SUBSCRIPTIONS_REVENUE,

        /// <summary>The number of active subscriptions present at the end of the period.</summary>
        ACTIVE_SUBSCRIPTIONS,

        /// <summary>The percentage of items not shipped out of total shipped units due to being out of stock.</summary>
        NOT_DELIVERED_DUE_TO_OOS,

        /// <summary>The average revenue per subscriber and non-subscriber over the past 12 months for sellers and 6 months for vendors.</summary>
        SUBSCRIBER_NON_SUBSCRIBER_AVERAGE_REVENUE,

        /// <summary>The revenue that would have been generated had there not been out of stock.</summary>
        LOST_REVENUE_DUE_TO_OOS,

        /// <summary>The average reorders per subscriber and non-subscriber over the last 12 months.</summary>
        SUBSCRIBER_NON_SUBSCRIBER_AVERAGE_REORDERS,

        /// <summary>The percentage of revenue from ASINs with coupons out of total revenue from all ASINs.</summary>
        COUPONS_REVENUE_PENETRATION,

        /// <summary>The revenue generated per delivery.</summary>
        REVENUE_BY_DELIVERIES,

        /// <summary>The percentage of subscribers retained over a period of time.</summary>
        SUBSCRIBER_RETENTION,

        /// <summary>The percentage of revenue attributed to seller-funded promotions.</summary>
        REVENUE_PENETRATION_BY_SELLER_FUNDING,

        /// <summary>The average revenue generated over the lifetime of a subscriber, segmented by customer type.</summary>
        SUBSCRIBER_LIFETIME_VALUE_BY_CUSTOMER_SEGMENT,

        /// <summary>The percentage of sign-ups that can be attributed to seller-funded promotions.</summary>
        SIGNUP_CONVERSION_BY_SELLER_FUNDING,

        /// <summary>The percentage of total revenue that comes from subscription orders.</summary>
        REVENUE_PENETRATION
    }
}
