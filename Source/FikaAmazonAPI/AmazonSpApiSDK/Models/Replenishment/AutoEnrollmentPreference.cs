using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Replenishment
{
    /// <summary>
    /// The seller's preference for automatic enrollment in the replenishment program.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AutoEnrollmentPreference
    {
        /// <summary>The seller has opted in to automatic enrollment.</summary>
        OPTED_IN,

        /// <summary>The seller has opted out of automatic enrollment.</summary>
        OPTED_OUT
    }
}
