using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Replenishment
{
    /// <summary>
    /// The time period type that determines whether the metrics requested are backward-looking (performance)
    /// or forward-looking (forecast).
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TimePeriodType
    {
        /// <summary>
        /// Indicates past performance metrics.
        /// </summary>
        PERFORMANCE,
        
        /// <summary>
        /// Indicates forecasted metrics. 
        /// </summary>
        /// <remarks>
        /// Only TOTAL_SUBSCRIPTIONS_REVENUE and SHIPPED_SUBSCRIPTION_UNITS are supported.
        /// Forecast data is supported for sellers but not for vendors.
        /// </remarks>
        FORECAST
    }
}