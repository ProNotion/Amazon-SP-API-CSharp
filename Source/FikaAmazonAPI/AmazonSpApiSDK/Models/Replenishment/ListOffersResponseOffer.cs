using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Replenishment
{
    /// <summary>
    /// A replenishment offer and its associated details.
    /// </summary>
    public class ListOffersResponseOffer
    {
        /// <summary>
        /// The Amazon Standard Identification Number (ASIN) of the offer.
        /// </summary>
        [DataMember(Name = "asin", EmitDefaultValue = false)]
        public string Asin { get; set; }

        /// <summary>
        /// Amazon marketplace identifier.
        /// </summary>
        [DataMember(Name = "marketplaceId", EmitDefaultValue = false)]
        public string MarketplaceId { get; set; }

        /// <summary>
        /// The eligibility status of the offer in the replenishment program.
        /// </summary>
        [DataMember(Name = "eligibilityStatus", EmitDefaultValue = false)]
        public EligibilityStatus? EligibilityStatus { get; set; }

        /// <summary>
        /// The program configuration for the offer.
        /// </summary>
        [DataMember(Name = "offerProgramConfiguration", EmitDefaultValue = false)]
        public OfferProgramConfiguration OfferProgramConfiguration { get; set; }

        /// <summary>
        /// The replenishment program type for the offer.
        /// </summary>
        [DataMember(Name = "programType", EmitDefaultValue = false)]
        public ProgramType? ProgramType { get; set; }

        /// <summary>
        /// A list of vendor codes associated with the offer.
        /// </summary>
        [DataMember(Name = "vendorCodes", EmitDefaultValue = false)]
        public List<string> VendorCodes { get; set; }

        /// <summary>
        /// The method by which the offer was enrolled in the replenishment program.
        /// </summary>
        [DataMember(Name = "enrollmentMethod", EmitDefaultValue = false)]
        public EnrollmentMethod? EnrollmentMethod { get; set; }

        /// <summary>
        /// The lowest number of days of supply forecasted over the next 90 days.
        /// </summary>
        [DataMember(Name = "lowestDaysSupplyOverNextNinetyDays", EmitDefaultValue = false)]
        public int? LowestDaysSupplyOverNextNinetyDays { get; set; }

        /// <summary>
        /// The forecasted P70 days of supply.
        /// </summary>
        [DataMember(Name = "forecastedP70DaysOfSupply", EmitDefaultValue = false)]
        public int? ForecastedP70DaysOfSupply { get; set; }

        /// <summary>
        /// The forecasted P80 days of supply.
        /// </summary>
        [DataMember(Name = "forecastedP80DaysOfSupply", EmitDefaultValue = false)]
        public int? ForecastedP80DaysOfSupply { get; set; }

        /// <summary>
        /// The forecasted P90 days of supply.
        /// </summary>
        [DataMember(Name = "forecastedP90DaysOfSupply", EmitDefaultValue = false)]
        public int? ForecastedP90DaysOfSupply { get; set; }

        /// <summary>
        /// A list of forecasted deliveries for the offer.
        /// </summary>
        [DataMember(Name = "forecastDeliveries", EmitDefaultValue = false)]
        public List<ForecastDelivery> ForecastDeliveries { get; set; }
    }
}
