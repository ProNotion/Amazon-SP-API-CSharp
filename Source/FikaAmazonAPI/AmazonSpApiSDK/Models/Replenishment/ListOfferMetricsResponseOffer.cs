using System.Runtime.Serialization;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Replenishment
{
    /// <summary>
    /// An offer and its associated replenishment metrics.
    /// </summary>
    public class ListOfferMetricsResponseOffer
    {
        /// <summary>
        /// The Amazon Standard Identification Number (ASIN) of the offer.
        /// </summary>
        [DataMember(Name = "asin", EmitDefaultValue = false)]
        public string Asin { get; set; }

        /// <summary>
        /// The replenishment metrics for the offer.
        /// </summary>
        [DataMember(Name = "metrics", EmitDefaultValue = false)]
        public ReplenishmentMetric Metrics { get; set; }
    }
}
