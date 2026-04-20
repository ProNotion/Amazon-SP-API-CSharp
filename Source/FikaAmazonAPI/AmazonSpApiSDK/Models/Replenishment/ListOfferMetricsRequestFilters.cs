using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Replenishment
{
    /// <summary>
    /// Use this parameter to filter the results.
    /// </summary>
    public class ListOfferMetricsRequestFilters
    {
        /// <summary>
        /// An optional time period used to group data in the response.
        /// </summary>
        [DataMember(Name = "aggregationFrequency", EmitDefaultValue = false)]
        public AggregationFrequency? AggregationFrequency { get; set; }

        /// <summary>
        /// A time interval used to compute metrics.
        /// </summary>
        [DataMember(Name = "timeInterval", EmitDefaultValue = false)]
        public TimeInterval TimeInterval { get; set; }

        /// <summary>
        /// The time period type that determines whether metrics are backward-looking (performance) or forward-looking (forecast).
        /// </summary>
        [DataMember(Name = "timePeriodType", EmitDefaultValue = false)]
        public TimePeriodType TimePeriodType { get; set; }

        /// <summary>
        /// Amazon marketplace identifier.
        /// </summary>
        [DataMember(Name = "marketplaceId", EmitDefaultValue = false)]
        public string MarketplaceId { get; set; }

        /// <summary>
        /// A list of replenishment program types by which to filter results.
        /// </summary>
        [DataMember(Name = "programTypes", EmitDefaultValue = false)]
        public List<ProgramType> ProgramTypes { get; set; }

        /// <summary>
        /// A list of ASINs by which to filter results.
        /// </summary>
        [DataMember(Name = "asins", EmitDefaultValue = false)]
        public List<string> Asins { get; set; }
    }
}
