using System.Runtime.Serialization;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Replenishment
{
    /// <summary>
    /// A forecasted delivery and its availability condition.
    /// </summary>
    public class ForecastDelivery
    {
        /// <summary>
        /// The condition of the forecasted delivery.
        /// </summary>
        [DataMember(Name = "deliveryCondition", EmitDefaultValue = false)]
        public string DeliveryCondition { get; set; }

        /// <summary>
        /// The estimated date of the forecasted delivery.
        /// </summary>
        [DataMember(Name = "estimatedDeliveryDate", EmitDefaultValue = false)]
        public string EstimatedDeliveryDate { get; set; }
    }
}
