using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Replenishment
{
    /// <summary>
    /// The sort order direction.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SortOrder
    {
        /// <summary>Sort in ascending order.</summary>
        ASC,

        /// <summary>Sort in descending order.</summary>
        DESC
    }
}
