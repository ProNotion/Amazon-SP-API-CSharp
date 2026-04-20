using System.Runtime.Serialization;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Replenishment
{
    /// <summary>
    /// Use this parameter to paginate through the response.
    /// </summary>
    public class ListOffersRequestPagination
    {
        /// <summary>
        /// The number of results to return per page.
        /// </summary>
        [DataMember(Name = "numberOfResults", EmitDefaultValue = false)]
        public int? NumberOfResults { get; set; }

        /// <summary>
        /// The token to retrieve the next page of results.
        /// </summary>
        [DataMember(Name = "nextToken", EmitDefaultValue = false)]
        public string NextToken { get; set; }
    }
}
