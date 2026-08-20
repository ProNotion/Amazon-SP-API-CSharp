using FikaAmazonAPI.Search;
using System;

namespace FikaAmazonAPI.Parameter.VendorShipments
{
    /// <summary>
    /// Query parameters for the Vendor Shipments getShipmentDetails operation.
    /// </summary>
    [CamelCase]
    public class ParameterGetShipmentDetails : ParameterBased
    {
        /// <summary>The limit to the number of records returned.</summary>
        public int? Limit { get; set; }

        /// <summary>Sort the list by shipment creation date. Values: ASC, DESC.</summary>
        public string SortOrder { get; set; }

        /// <summary>A token used to retrieve the next page of results.</summary>
        public string NextToken { get; set; }

        public DateTime? CreatedAfter { get; set; }
        public DateTime? CreatedBefore { get; set; }
        public DateTime? ShipmentConfirmedBefore { get; set; }
        public DateTime? ShipmentConfirmedAfter { get; set; }
        public DateTime? PackageLabelCreatedBefore { get; set; }
        public DateTime? PackageLabelCreatedAfter { get; set; }
        public DateTime? ShippedBefore { get; set; }
        public DateTime? ShippedAfter { get; set; }
        public DateTime? EstimatedDeliveryBefore { get; set; }
        public DateTime? EstimatedDeliveryAfter { get; set; }
        public DateTime? ShipmentDeliveryBefore { get; set; }
        public DateTime? ShipmentDeliveryAfter { get; set; }
        public DateTime? RequestedPickUpBefore { get; set; }
        public DateTime? RequestedPickUpAfter { get; set; }
        public DateTime? ScheduledPickUpBefore { get; set; }
        public DateTime? ScheduledPickUpAfter { get; set; }

        /// <summary>The current shipment status filter.</summary>
        public string CurrentShipmentStatus { get; set; }

        /// <summary>The vendor-provided shipment ID.</summary>
        public string VendorShipmentIdentifier { get; set; }

        public string BuyerReferenceNumber { get; set; }
        public string BuyerWarehouseCode { get; set; }
        public string SellerWarehouseCode { get; set; }
    }
}
