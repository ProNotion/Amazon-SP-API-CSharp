using System.Runtime.Serialization;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Replenishment
{
    /// <summary>
    /// Pagination details returned in a list response.
    /// </summary>
    public class PaginationResponse
    {
        /// <summary>
        /// A token that can be used to retrieve the next page of results.
        /// </summary>
        [DataMember(Name = "nextToken", EmitDefaultValue = false)]
        public string NextToken { get; set; }
    }
}
