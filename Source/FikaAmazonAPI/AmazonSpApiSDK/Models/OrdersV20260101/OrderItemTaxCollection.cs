using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.OrdersV20260101
{
    /// <summary>
    /// Represents a single tax collection entry for an order item,
    /// containing the responsible party and the applied tax model.
    /// </summary>
    [DataContract]
    public partial class OrderItemTaxCollection : IEquatable<OrderItemTaxCollection>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderItemTaxCollection"/> class.
        /// </summary>
        public OrderItemTaxCollection()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderItemTaxCollection"/> class.
        /// </summary>
        /// <param name="responsibleParty">The party responsible for collecting the tax (e.g. "Amazon EU S.a.r.L.").</param>
        /// <param name="model">The tax collection model applied to this order item.</param>
        public OrderItemTaxCollection(string responsibleParty, OrderItemTaxCollectionEnum? model = null)
        {
            this.ResponsibleParty = responsibleParty;
            this.Model = model;
        }

        /// <summary>
        /// The party responsible for collecting the tax for this order item (e.g. "Amazon EU S.a.r.L.").
        /// </summary>
        [DataMember(Name = "responsibleParty", EmitDefaultValue = false)]
        public string ResponsibleParty { get; set; }

        /// <summary>
        /// The tax collection model applied to this order item.
        /// </summary>
        [DataMember(Name = "model", EmitDefaultValue = false)]
        public OrderItemTaxCollectionEnum? Model { get; set; }

        /// <summary>
        /// Returns the string representation of the object.
        /// </summary>
        /// <returns>String representation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class OrderItemTaxCollection {\n");
            sb.Append("  ResponsibleParty: ").Append(ResponsibleParty).Append("\n");
            sb.Append("  Model: ").Append(Model).Append("\n");
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
            return this.Equals(obj as OrderItemTaxCollection);
        }

        /// <summary>
        /// Returns true if the given <see cref="OrderItemTaxCollection"/> instance is equal to this instance.
        /// </summary>
        /// <param name="input">Instance of <see cref="OrderItemTaxCollection"/> to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(OrderItemTaxCollection input)
        {
            if (input == null)
                return false;

            return
                (
                    this.ResponsibleParty == input.ResponsibleParty ||
                    (this.ResponsibleParty != null &&
                     this.ResponsibleParty.Equals(input.ResponsibleParty))
                ) &&
                (
                    this.Model == input.Model
                );
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
                if (this.ResponsibleParty != null)
                    hashCode = hashCode * 59 + this.ResponsibleParty.GetHashCode();
                hashCode = hashCode * 59 + this.Model.GetHashCode();
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