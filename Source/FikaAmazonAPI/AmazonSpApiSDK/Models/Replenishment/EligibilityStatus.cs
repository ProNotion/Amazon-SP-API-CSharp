using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Replenishment
{
    /// <summary>
    /// The eligibility status of an offer in the replenishment program.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum EligibilityStatus
    {
        /// <summary>The offer is eligible for the replenishment program.</summary>
        ELIGIBLE,

        /// <summary>The offer is not eligible for the replenishment program.</summary>
        INELIGIBLE,

        /// <summary>The offer has been suspended from the replenishment program.</summary>
        SUSPENDED,

        /// <summary>The offer is available for replenishment-only ordering.</summary>
        REPLENISHMENT_ONLY_ORDERING
    }
}
