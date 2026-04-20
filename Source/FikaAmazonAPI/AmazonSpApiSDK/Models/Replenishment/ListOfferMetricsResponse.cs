using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Replenishment
{
    /// <summary>
    /// The response body for the listOfferMetrics operation.
    /// </summary>
    public class ListOfferMetricsResponse
    {
        /// <summary>
        /// A list of offers and their associated replenishment metrics.
        /// </summary>
        [DataMember(Name = "offers", EmitDefaultValue = false)]
        public List<ListOfferMetricsResponseOffer> Offers { get; set; }

        /// <summary>
        /// Pagination details for the response.
        /// </summary>
        [DataMember(Name = "pagination", EmitDefaultValue = false)]
        public PaginationResponse Pagination { get; set; }
    }
}
