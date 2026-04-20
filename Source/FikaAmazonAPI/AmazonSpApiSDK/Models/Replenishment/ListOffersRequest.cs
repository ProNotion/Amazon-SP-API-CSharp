using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Replenishment
{
    /// <summary>
    /// The request body for the listOffers operation.
    /// </summary>
    public class ListOffersRequest
    {
        [JsonConstructor]
        public ListOffersRequest() { }

        /// <summary>
        /// Pagination parameters for the response.
        /// </summary>
        [DataMember(Name = "pagination", EmitDefaultValue = false)]
        public ListOffersRequestPagination Pagination { get; set; }

        /// <summary>
        /// Filters to apply to the results.
        /// </summary>
        [DataMember(Name = "filters", EmitDefaultValue = false)]
        public ListOffersRequestFilters Filters { get; set; }

        /// <summary>
        /// Sort options for the results.
        /// </summary>
        [DataMember(Name = "sort", EmitDefaultValue = false)]
        public ListOffersRequestSort Sort { get; set; }
    }
}
