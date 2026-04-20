using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Replenishment
{
    /// <summary>
    /// Enum representing different aggregation frequencies for data.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AggregationFrequency
    {
        /// <summary>
        /// ISO Calendar Week
        /// </summary>
        WEEK,
        /// <summary>
        /// ISO Calendar Month
        /// </summary>
        MONTH,
        /// <summary>
        /// ISO Calendar Quarter
        /// </summary>
        QUARTER,
        /// <summary>
        /// ISO Calendar Year
        /// </summary>
        YEAR
    }
}