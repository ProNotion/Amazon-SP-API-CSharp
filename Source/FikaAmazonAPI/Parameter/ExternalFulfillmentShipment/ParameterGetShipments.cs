using FikaAmazonAPI.AmazonSpApiSDK.Models.ExternalFulfillmentShipment;
using FikaAmazonAPI.Search;
using System;

namespace FikaAmazonAPI.Parameter.ExternalFulfillmentShipment
{
    [CamelCase]
    public class ParameterGetShipments : ParameterBased
    {
        /// <summary>
        /// The status of shipment you want to include in the response. To retrieve all new shipments, set this value to CREATED or ACCEPTED. (required)
        /// </summary>
        public Shipment.StatusEnum? Status { get; set; }

        /// <summary>
        /// The Amazon channel location identifier for the shipments you want to retrieve.
        /// </summary>
        public string LocationId { get; set; }

        /// <summary>
        /// The marketplace ID associated with the location.
        /// </summary>
        public string MarketplaceId { get; set; }

        /// <summary>
        /// The channel name associated with the location.
        /// </summary>
        public string ChannelName { get; set; }

        /// <summary>
        /// The response includes shipments whose latest update is after the specified time.
        /// </summary>
        public DateTime? LastUpdatedAfter { get; set; }

        /// <summary>
        /// The response includes shipments whose latest update is before the specified time.
        /// </summary>
        public DateTime? LastUpdatedBefore { get; set; }

        /// <summary>
        /// The maximum number of shipments to include in the response. The value must be between 1 and 100.
        /// </summary>
        public int? MaxResults { get; set; }

        /// <summary>
        /// A token that you use to retrieve the next page of results. The response includes nextToken when there are multiple pages of results.
        /// </summary>
        public string? PaginationToken { get; set; }

        /// <summary>
        /// Maximum number of pages to return. When null, all pages are fetched.
        /// </summary>
        [IgnoreToAddParameter]
        public int? MaxNumberOfPages { get; set; }
    }
}
