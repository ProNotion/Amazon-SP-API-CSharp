using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Replenishment
{
    /// <summary>
    /// The response body for the getSellingPartnerMetrics operation.
    /// </summary>
    public class GetSellingPartnerMetricsResponse
    {
        /// <summary>
        /// A list of metrics for the selling partner account.
        /// </summary>
        [DataMember(Name = "metrics", EmitDefaultValue = false)]
        public List<ReplenishmentMetric> Metrics { get; set; }
    }
}
