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
    /// Represents tax information for an order item, containing a list of tax collections.
    /// </summary>
    [DataContract]
    public partial class OrderItemTax : IEquatable<OrderItemTax>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderItemTax"/> class.
        /// </summary>
        public OrderItemTax()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderItemTax"/> class.
        /// </summary>
        /// <param name="orderItemTaxCollections">A list of tax collections associated with this order item.</param>
        public OrderItemTax(List<OrderItemTaxCollection> orderItemTaxCollections)
        {
            this.TaxCollection = orderItemTaxCollections;
        }

        /// <summary>
        /// A list of tax collections for this order item.
        /// Each entry contains details about the responsible party and the tax model (e.g. MARKETPLACE_FACILITATOR).
        /// </summary>
        [DataMember(Name = "taxCollections", EmitDefaultValue = false)]
        public List<OrderItemTaxCollection> TaxCollection { get; set; }

        /// <summary>
        /// Returns the string representation of the object.
        /// </summary>
        /// <returns>String representation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class OrderItemTax {\n");
            sb.Append("  TaxCollection: ").Append(TaxCollection).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string representation of the object.
        /// </summary>
        /// <returns>JSON string representation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if the given object is equal to this instance.
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            return this.Equals(obj as OrderItemTax);
        }

        /// <summary>
        /// Returns true if the given <see cref="OrderItemTax"/> instance is equal to this instance.
        /// </summary>
        /// <param name="input">Instance of <see cref="OrderItemTax"/> to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(OrderItemTax input)
        {
            if (input == null)
                return false;

            return
                this.TaxCollection == input.TaxCollection ||
                (this.TaxCollection != null &&
                 this.TaxCollection.SequenceEqual(input.TaxCollection));
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 41;
                if (this.TaxCollection != null)
                    hashCode = hashCode * 59 + this.TaxCollection.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// Validates all properties of the instance.
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation results</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}