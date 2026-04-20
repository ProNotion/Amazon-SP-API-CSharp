using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Replenishment
{
    /// <summary>
    /// The request body for the listOfferMetrics operation.
    /// </summary>
    public class ListOfferMetricsRequest
    {
        [JsonConstructor]
        public ListOfferMetricsRequest() { }

        /// <summary>
        /// Pagination parameters for the response.
        /// </summary>
        [DataMember(Name = "pagination", EmitDefaultValue = false)]
        public ListOfferMetricsRequestPagination Pagination { get; set; }

        /// <summary>
        /// Filters to apply to the results.
        /// </summary>
        [DataMember(Name = "filters", EmitDefaultValue = false)]
        public ListOfferMetricsRequestFilters Filters { get; set; }

        /// <summary>
        /// Sort options for the results.
        /// </summary>
        [DataMember(Name = "sort", EmitDefaultValue = false)]
        public ListOfferMetricsRequestSort Sort { get; set; }
    }
}
