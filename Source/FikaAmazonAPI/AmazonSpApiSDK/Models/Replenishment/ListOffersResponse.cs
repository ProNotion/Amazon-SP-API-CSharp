using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Replenishment
{
    /// <summary>
    /// The response body for the listOffers operation.
    /// </summary>
    public class ListOffersResponse
    {
        /// <summary>
        /// A list of replenishment offers.
        /// </summary>
        [DataMember(Name = "offers", EmitDefaultValue = false)]
        public List<ListOffersResponseOffer> Offers { get; set; }

        /// <summary>
        /// Pagination details for the response.
        /// </summary>
        [DataMember(Name = "pagination", EmitDefaultValue = false)]
        public PaginationResponse Pagination { get; set; }
    }
}
