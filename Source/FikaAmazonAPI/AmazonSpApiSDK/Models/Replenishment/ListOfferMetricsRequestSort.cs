using System.Runtime.Serialization;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Replenishment
{
    /// <summary>
    /// Use this parameter to sort the results.
    /// </summary>
    public class ListOfferMetricsRequestSort
    {
        /// <summary>
        /// The sort order.
        /// </summary>
        [DataMember(Name = "order", EmitDefaultValue = false)]
        public SortOrder Order { get; set; }

        /// <summary>
        /// The attribute by which to sort the results.
        /// </summary>
        [DataMember(Name = "key", EmitDefaultValue = false)]
        public ListOfferMetricsSortKey Key { get; set; }
    }
}
