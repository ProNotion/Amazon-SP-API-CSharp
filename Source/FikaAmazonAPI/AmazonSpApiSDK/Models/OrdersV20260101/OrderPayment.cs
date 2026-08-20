using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.OrdersV20260101
{
    /// <summary>
    /// Payment information about the order.
    /// </summary>
    [DataContract]
    public partial class OrderPayment : IEquatable<OrderPayment>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderPayment" /> class.
        /// </summary>
        public OrderPayment()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderPayment" /> class.
        /// </summary>
        /// <param name="paymentExecutions">A list of payment executions for the order.</param>
        public OrderPayment(List<PaymentExecution> paymentExecutions)
        {
            this.PaymentExecutions = paymentExecutions;
        }

        /// <summary>
        /// A list of payment executions for the order.
        /// </summary>
        /// <value>A list of payment executions for the order.</value>
        [DataMember(Name = "paymentExecutions", EmitDefaultValue = false)]
        public List<PaymentExecution> PaymentExecutions { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class OrderPayment {\n");
            sb.Append("  PaymentExecutions: ").Append(PaymentExecutions).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            return this.Equals(obj as OrderPayment);
        }

        /// <summary>
        /// Returns true if OrderPayment instances are equal
        /// </summary>
        /// <param name="input">Instance of OrderPayment to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(OrderPayment input)
        {
            if (input == null)
                return false;

            return
                (
                    this.PaymentExecutions == input.PaymentExecutions ||
                    (this.PaymentExecutions != null &&
                    this.PaymentExecutions.SequenceEqual(input.PaymentExecutions))
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
                if (this.PaymentExecutions != null)
                {
                    foreach (var paymentExecution in this.PaymentExecutions)
                        hashCode = hashCode * 59 + (paymentExecution?.GetHashCode() ?? 0);
                }
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
