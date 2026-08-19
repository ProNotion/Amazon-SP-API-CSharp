using FikaAmazonAPI.Search;
using System;

namespace FikaAmazonAPI.Parameter.VendorDirectFulfillmentShipping
{
    /// <summary>
    /// Shared query parameters for the paged Vendor Direct Fulfillment Shipping list operations
    /// (getShippingLabels, getCustomerInvoices, getPackingSlips).
    /// </summary>
    [CamelCase]
    public class ParameterVendorDirectFulfillmentShippingList : ParameterBased
    {
        /// <summary>
        /// The vendor shipFromPartyId for the items shipped.
        /// </summary>
        public string ShipFromPartyId { get; set; }

        /// <summary>
        /// The limit to the number of records returned. Must be between 1 and 100.
        /// </summary>
        public int? Limit { get; set; }

        /// <summary>
        /// Records created after this date/time (inclusive). Must be within 7 days of createdBefore.
        /// </summary>
        public DateTime? CreatedAfter { get; set; }

        /// <summary>
        /// Records created before this date/time (inclusive). Must be within 7 days of createdAfter.
        /// </summary>
        public DateTime? CreatedBefore { get; set; }

        /// <summary>
        /// Sort the list in ascending or descending order by order creation date. Values: ASC, DESC.
        /// </summary>
        public string SortOrder { get; set; }

        /// <summary>
        /// A token used to retrieve the next page of results.
        /// </summary>
        public string NextToken { get; set; }
    }
}
