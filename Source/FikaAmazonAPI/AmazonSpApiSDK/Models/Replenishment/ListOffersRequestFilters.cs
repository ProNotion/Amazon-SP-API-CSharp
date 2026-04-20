using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Replenishment
{
    /// <summary>
    /// Use this parameter to filter the results.
    /// </summary>
    public class ListOffersRequestFilters
    {
        /// <summary>
        /// Amazon marketplace identifier.
        /// </summary>
        [DataMember(Name = "marketplaceId", EmitDefaultValue = false)]
        public string MarketplaceId { get; set; }

        /// <summary>
        /// A list of SKUs by which to filter results.
        /// </summary>
        [DataMember(Name = "skus", EmitDefaultValue = false)]
        public List<string> Skus { get; set; }

        /// <summary>
        /// A list of ASINs by which to filter results.
        /// </summary>
        [DataMember(Name = "asins", EmitDefaultValue = false)]
        public List<string> Asins { get; set; }

        /// <summary>
        /// A list of eligibility statuses by which to filter results.
        /// </summary>
        [DataMember(Name = "eligibilityStatuses", EmitDefaultValue = false)]
        public List<EligibilityStatus> EligibilityStatuses { get; set; }

        /// <summary>
        /// A list of replenishment program types by which to filter results.
        /// </summary>
        [DataMember(Name = "programTypes", EmitDefaultValue = false)]
        public List<ProgramType> ProgramTypes { get; set; }
    }
}
