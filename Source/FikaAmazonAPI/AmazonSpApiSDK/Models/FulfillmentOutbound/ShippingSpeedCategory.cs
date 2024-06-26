/* 
 * Selling Partner API for Fulfillment Outbound
 *
 * The Selling Partner API for Fulfillment Outbound lets you create applications that help a seller fulfill Multi-Channel Fulfillment orders using their inventory in Amazon's fulfillment network. You can get information on both potential and existing fulfillment orders.
 *
 * OpenAPI spec version: v0
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.FulfillmentOutbound
{
    /// <summary>
    /// The shipping method used for the fulfillment order.
    /// </summary>
    /// <value>The shipping method used for the fulfillment order.</value>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ShippingSpeedCategory
    {

        /// <summary>
        /// Enum Standard for value: Standard
        /// </summary>

        [EnumMember(Value = "Standard")]
        Standard,

        /// <summary>
        /// Enum Expedited for value: Expedited
        /// </summary>

        [EnumMember(Value = "Expedited")]
        Expedited,

        /// <summary>
        /// Enum Priority for value: Priority
        /// </summary>

        [EnumMember(Value = "Priority")]
        Priority,

        /// <summary>
        /// Enum ScheduledDelivery for value: ScheduledDelivery
        /// </summary>

        [EnumMember(Value = "ScheduledDelivery")]
        ScheduledDelivery
    }

}
