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
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.FulfillmentOutbound
{
    /// <summary>
    /// The time range within which a Scheduled Delivery fulfillment order should be delivered.
    /// </summary>
    [DataContract]
    public partial class DeliveryWindow : IEquatable<DeliveryWindow>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeliveryWindow" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        public DeliveryWindow() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="DeliveryWindow" /> class.
        /// </summary>
        /// <param name="StartDate">The date and time of the start of the Scheduled Delivery window, in ISO 8601 date time format. (required).</param>
        /// <param name="EndDate">The date and time of the end of the Scheduled Delivery window, in ISO 8601 date time format. (required).</param>
        public DeliveryWindow(DateTime? StartDate = null, DateTime? EndDate = null)
        {
            // to ensure "StartDateTime" is required (not null)
            if (StartDate == null)
            {
                throw new InvalidDataException("StartDateTime is a required property for DeliveryWindow and cannot be null");
            }
            else
            {
                this.StartDate = StartDate;
            }
            // to ensure "EndDateTime" is required (not null)
            if (EndDate == null)
            {
                throw new InvalidDataException("EndDateTime is a required property for DeliveryWindow and cannot be null");
            }
            else
            {
                this.EndDate = EndDate;
            }
        }

        /// <summary>
        /// The date and time of the start of the Scheduled Delivery window, in ISO 8601 date time format.
        /// </summary>
        /// <value>The date and time of the start of the Scheduled Delivery window, in ISO 8601 date time format.</value>
        [DataMember(Name = "StartDate", EmitDefaultValue = false)]
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// The date and time of the end of the Scheduled Delivery window, in ISO 8601 date time format.
        /// </summary>
        /// <value>The date and time of the end of the Scheduled Delivery window, in ISO 8601 date time format.</value>
        [DataMember(Name = "EndDate", EmitDefaultValue = false)]
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class DeliveryWindow {\n");
            sb.Append("  StartDate: ").Append(StartDate).Append("\n");
            sb.Append("  EndDate: ").Append(EndDate).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as DeliveryWindow);
        }

        /// <summary>
        /// Returns true if DeliveryWindow instances are equal
        /// </summary>
        /// <param name="input">Instance of DeliveryWindow to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DeliveryWindow input)
        {
            if (input == null)
                return false;

            return
                (
                    this.StartDate == input.StartDate ||
                    (this.StartDate != null &&
                    this.StartDate.Equals(input.StartDate))
                ) &&
                (
                    this.EndDate == input.EndDate ||
                    (this.EndDate != null &&
                    this.EndDate.Equals(input.EndDate))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.StartDate != null)
                    hashCode = hashCode * 59 + this.StartDate.GetHashCode();
                if (this.EndDate != null)
                    hashCode = hashCode * 59 + this.EndDate.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}
