using FikaAmazonAPI.Search;
using System;

namespace FikaAmazonAPI.Parameter.VendorShipments
{
    /// <summary>
    /// Query parameters for the Vendor Shipments getShipmentLabels operation.
    /// </summary>
    [CamelCase]
    public class ParameterGetShipmentLabels : ParameterBased
    {
        /// <summary>The limit to the number of records returned.</summary>
        public int? Limit { get; set; }

        /// <summary>Sort the list by label creation date. Values: ASC, DESC.</summary>
        public string SortOrder { get; set; }

        /// <summary>A token used to retrieve the next page of results.</summary>
        public string NextToken { get; set; }

        public DateTime? LabelCreatedAfter { get; set; }
        public DateTime? LabelCreatedBefore { get; set; }

        public string BuyerReferenceNumber { get; set; }
        public string VendorShipmentIdentifier { get; set; }
        public string SellerWarehouseCode { get; set; }
    }
}
