using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Replenishment
{
    /// <summary>
    /// The attribute by which to sort the listOffers response.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ListOffersSortKey
    {
        /// <summary>Sort by ASIN.</summary>
        ASIN,

        /// <summary>Sort by marketplace identifier.</summary>
        MARKETPLACE_ID,

        /// <summary>Sort by eligibility status.</summary>
        ELIGIBILITY_STATUS,

        /// <summary>Sort by enrollment method.</summary>
        ENROLLMENT_METHOD,

        /// <summary>Sort by lowest days of supply over the next 90 days.</summary>
        LOWEST_DAYS_SUPPLY_OVER_NEXT_NINETY_DAYS,

        /// <summary>Sort by forecasted P70 days of supply.</summary>
        FORECASTED_P70_DAYS_OF_SUPPLY,

        /// <summary>Sort by forecasted P80 days of supply.</summary>
        FORECASTED_P80_DAYS_OF_SUPPLY,

        /// <summary>Sort by forecasted P90 days of supply.</summary>
        FORECASTED_P90_DAYS_OF_SUPPLY
    }
}
