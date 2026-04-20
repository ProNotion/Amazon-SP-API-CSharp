using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Replenishment
{
    /// <summary>
    /// The method by which an offer was enrolled in the replenishment program.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum EnrollmentMethod
    {
        /// <summary>The offer was manually enrolled by the seller.</summary>
        MANUAL,

        /// <summary>The offer was automatically enrolled by Amazon.</summary>
        AUTOMATIC
    }
}
