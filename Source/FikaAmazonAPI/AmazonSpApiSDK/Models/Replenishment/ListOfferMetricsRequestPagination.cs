using System.Runtime.Serialization;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Replenishment
{
    /// <summary>
    /// Use this parameter to paginate through the response.
    /// </summary>
    public class ListOfferMetricsRequestPagination
    {
        /// <summary>
        /// The number of results to return per page.
        /// </summary>
        [DataMember(Name = "numberOfResults", EmitDefaultValue = false)]
        public int? NumberOfResults { get; set; }
    }
}
