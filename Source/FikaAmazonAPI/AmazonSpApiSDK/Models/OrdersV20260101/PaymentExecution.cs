using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.OrdersV20260101
{
    /// <summary>
    /// Payment execution details for an order.
    /// </summary>
    [DataContract]
    public partial class PaymentExecution : IEquatable<PaymentExecution>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentExecution" /> class.
        /// </summary>
        public PaymentExecution()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentExecution" /> class.
        /// </summary>
        /// <param name="paymentMethod">The payment method used for this payment execution (for example, CashOnDelivery, ConvenienceStore, CreditCard, Invoice, Pix, and so on).</param>
        /// <param name="paymentAmount">The monetary value of the payment execution.</param>
        /// <param name="acquirerId">The unique identifier of the payment processor or acquiring bank that authorizes the payment.</param>
        /// <param name="cardBrand">The card network or brand used in the payment transaction (for example, Visa or Mastercard).</param>
        /// <param name="authorizationCode">The unique code that confirms the payment authorization.</param>
        public PaymentExecution(string paymentMethod, Money paymentAmount, string acquirerId, string cardBrand, string authorizationCode)
        {
            this.PaymentMethod = paymentMethod;
            this.PaymentAmount = paymentAmount;
            this.AcquirerId = acquirerId;
            this.CardBrand = cardBrand;
            this.AuthorizationCode = authorizationCode;
        }

        /// <summary>
        /// The payment method used for this payment execution (for example, CashOnDelivery, ConvenienceStore, CreditCard, Invoice, Pix, and so on).
        /// </summary>
        /// <value>The payment method used for this payment execution (for example, CashOnDelivery, ConvenienceStore, CreditCard, Invoice, Pix, and so on).</value>
        [DataMember(Name = "paymentMethod", EmitDefaultValue = false)]
        public string PaymentMethod { get; set; }

        /// <summary>
        /// The monetary value of the payment execution.
        /// </summary>
        /// <value>The monetary value of the payment execution.</value>
        [DataMember(Name = "paymentAmount", EmitDefaultValue = false)]
        public Money PaymentAmount { get; set; }

        /// <summary>
        /// The unique identifier of the payment processor or acquiring bank that authorizes the payment.
        /// <br/><br/>
        /// Note: This attribute is only available for orders in the Brazil (BR) marketplace when the paymentMethod is CreditCard or Pix.
        /// </summary>
        /// <value>The unique identifier of the payment processor or acquiring bank that authorizes the payment.</value>
        [DataMember(Name = "acquirerId", EmitDefaultValue = false)]
        public string AcquirerId { get; set; }

        /// <summary>
        /// The card network or brand used in the payment transaction (for example, Visa or Mastercard).
        /// <br/><br/>
        /// Note: This attribute is only available for orders in the Brazil (BR) marketplace when the paymentMethod is CreditCard.
        /// </summary>
        /// <value>The card network or brand used in the payment transaction (for example, Visa or Mastercard).</value>
        [DataMember(Name = "cardBrand", EmitDefaultValue = false)]
        public string CardBrand { get; set; }

        /// <summary>
        /// The unique code that confirms the payment authorization.
        /// <br/><br/>
        /// Note: This attribute is only available for orders in the Brazil (BR) marketplace when the paymentMethod is CreditCard or Pix.
        /// </summary>
        /// <value>The unique code that confirms the payment authorization.</value>
        [DataMember(Name = "authorizationCode", EmitDefaultValue = false)]
        public string AuthorizationCode { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PaymentExecution {\n");
            sb.Append("  PaymentMethod: ").Append(PaymentMethod).Append("\n");
            sb.Append("  PaymentAmount: ").Append(PaymentAmount).Append("\n");
            sb.Append("  AcquirerId: ").Append(AcquirerId).Append("\n");
            sb.Append("  CardBrand: ").Append(CardBrand).Append("\n");
            sb.Append("  AuthorizationCode: ").Append(AuthorizationCode).Append("\n");
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
            return this.Equals(obj as PaymentExecution);
        }

        /// <summary>
        /// Returns true if PaymentExecution instances are equal
        /// </summary>
        /// <param name="input">Instance of PaymentExecution to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PaymentExecution input)
        {
            if (input == null)
                return false;

            return
                (
                    this.PaymentMethod == input.PaymentMethod ||
                    (this.PaymentMethod != null &&
                    this.PaymentMethod.Equals(input.PaymentMethod))
                ) &&
                (
                    this.PaymentAmount == input.PaymentAmount ||
                    (this.PaymentAmount != null &&
                    this.PaymentAmount.Equals(input.PaymentAmount))
                ) &&
                (
                    this.AcquirerId == input.AcquirerId ||
                    (this.AcquirerId != null &&
                    this.AcquirerId.Equals(input.AcquirerId))
                ) &&
                (
                    this.CardBrand == input.CardBrand ||
                    (this.CardBrand != null &&
                    this.CardBrand.Equals(input.CardBrand))
                ) &&
                (
                    this.AuthorizationCode == input.AuthorizationCode ||
                    (this.AuthorizationCode != null &&
                    this.AuthorizationCode.Equals(input.AuthorizationCode))
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
                if (this.PaymentMethod != null)
                    hashCode = hashCode * 59 + this.PaymentMethod.GetHashCode();
                if (this.PaymentAmount != null)
                    hashCode = hashCode * 59 + this.PaymentAmount.GetHashCode();
                if (this.AcquirerId != null)
                    hashCode = hashCode * 59 + this.AcquirerId.GetHashCode();
                if (this.CardBrand != null)
                    hashCode = hashCode * 59 + this.CardBrand.GetHashCode();
                if (this.AuthorizationCode != null)
                    hashCode = hashCode * 59 + this.AuthorizationCode.GetHashCode();
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
