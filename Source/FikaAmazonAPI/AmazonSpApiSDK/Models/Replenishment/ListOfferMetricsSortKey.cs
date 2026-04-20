using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Replenishment
{
    /// <summary>
    /// The attribute by which to sort the listOfferMetrics response.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ListOfferMetricsSortKey
    {
        /// <summary>Sort by shipped subscription units.</summary>
        SHIPPED_SUBSCRIPTION_UNITS,

        /// <summary>Sort by total subscriptions revenue.</summary>
        TOTAL_SUBSCRIPTIONS_REVENUE,

        /// <summary>Sort by active subscriptions.</summary>
        ACTIVE_SUBSCRIPTIONS,

        /// <summary>Sort by percentage not delivered due to out of stock.</summary>
        NOT_DELIVERED_DUE_TO_OOS,

        /// <summary>Sort by subscriber to non-subscriber average revenue ratio.</summary>
        SUBSCRIBER_NON_SUBSCRIBER_AVERAGE_REVENUE,

        /// <summary>Sort by lost revenue due to out of stock.</summary>
        LOST_REVENUE_DUE_TO_OOS,

        /// <summary>Sort by subscriber to non-subscriber average reorders ratio.</summary>
        SUBSCRIBER_NON_SUBSCRIBER_AVERAGE_REORDERS,

        /// <summary>Sort by coupons revenue penetration.</summary>
        COUPONS_REVENUE_PENETRATION,

        /// <summary>Sort by revenue by deliveries.</summary>
        REVENUE_BY_DELIVERIES
    }
}
