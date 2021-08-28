/* 
 * Selling Partner API for Pricing
 *
 * The Selling Partner API for Pricing helps you programmatically retrieve product pricing and offer information for Amazon Marketplace products.
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

namespace AmazonSpApiSDK.Models.ProductPricing
{
    /// <summary>
    /// CompetitivePriceType
    /// </summary>
    [DataContract]
    public partial class CompetitivePriceType : IEquatable<CompetitivePriceType>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CompetitivePriceType" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected CompetitivePriceType() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="CompetitivePriceType" /> class.
        /// </summary>
        /// <param name="CompetitivePriceId">The pricing model for each price that is returned.  Possible values:  * 1 - New Buy Box Price. * 2 - Used Buy Box Price. (required).</param>
        /// <param name="Price">Pricing information for a given CompetitivePriceId value. (required).</param>
        /// <param name="Condition">Indicates the condition of the item whose pricing information is returned. Possible values are: New, Used, Collectible, Refurbished, or Club..</param>
        /// <param name="Subcondition">Indicates the subcondition of the item whose pricing information is returned. Possible values are: New, Mint, Very Good, Good, Acceptable, Poor, Club, OEM, Warranty, Refurbished Warranty, Refurbished, Open Box, or Other..</param>
        /// <param name="BelongsToRequester"> Indicates whether or not the pricing information is for an offer listing that belongs to the requester. The requester is the seller associated with the SellerId that was submitted with the request. Possible values are: true and false..</param>
        public CompetitivePriceType(string CompetitivePriceId = default(string), PriceType Price = default(PriceType), string Condition = default(string), string Subcondition = default(string), bool? BelongsToRequester = default(bool?))
        {
            // to ensure "CompetitivePriceId" is required (not null)
            if (CompetitivePriceId == null)
            {
                throw new InvalidDataException("CompetitivePriceId is a required property for CompetitivePriceType and cannot be null");
            }
            else
            {
                this.CompetitivePriceId = CompetitivePriceId;
            }
            // to ensure "Price" is required (not null)
            if (Price == null)
            {
                throw new InvalidDataException("Price is a required property for CompetitivePriceType and cannot be null");
            }
            else
            {
                this.Price = Price;
            }
            this.Condition = Condition;
            this.Subcondition = Subcondition;
            this.BelongsToRequester = BelongsToRequester;
        }

        /// <summary>
        /// The pricing model for each price that is returned.  Possible values:  * 1 - New Buy Box Price. * 2 - Used Buy Box Price.
        /// </summary>
        /// <value>The pricing model for each price that is returned.  Possible values:  * 1 - New Buy Box Price. * 2 - Used Buy Box Price.</value>
        [DataMember(Name = "CompetitivePriceId", EmitDefaultValue = false)]
        public string CompetitivePriceId { get; set; }

        /// <summary>
        /// Pricing information for a given CompetitivePriceId value.
        /// </summary>
        /// <value>Pricing information for a given CompetitivePriceId value.</value>
        [DataMember(Name = "Price", EmitDefaultValue = false)]
        public PriceType Price { get; set; }

        /// <summary>
        /// Indicates the condition of the item whose pricing information is returned. Possible values are: New, Used, Collectible, Refurbished, or Club.
        /// </summary>
        /// <value>Indicates the condition of the item whose pricing information is returned. Possible values are: New, Used, Collectible, Refurbished, or Club.</value>
        [DataMember(Name = "condition", EmitDefaultValue = false)]
        public string Condition { get; set; }

        /// <summary>
        /// Indicates the subcondition of the item whose pricing information is returned. Possible values are: New, Mint, Very Good, Good, Acceptable, Poor, Club, OEM, Warranty, Refurbished Warranty, Refurbished, Open Box, or Other.
        /// </summary>
        /// <value>Indicates the subcondition of the item whose pricing information is returned. Possible values are: New, Mint, Very Good, Good, Acceptable, Poor, Club, OEM, Warranty, Refurbished Warranty, Refurbished, Open Box, or Other.</value>
        [DataMember(Name = "subcondition", EmitDefaultValue = false)]
        public string Subcondition { get; set; }

        /// <summary>
        ///  Indicates whether or not the pricing information is for an offer listing that belongs to the requester. The requester is the seller associated with the SellerId that was submitted with the request. Possible values are: true and false.
        /// </summary>
        /// <value> Indicates whether or not the pricing information is for an offer listing that belongs to the requester. The requester is the seller associated with the SellerId that was submitted with the request. Possible values are: true and false.</value>
        [DataMember(Name = "belongsToRequester", EmitDefaultValue = false)]
        public bool? BelongsToRequester { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CompetitivePriceType {\n");
            sb.Append("  CompetitivePriceId: ").Append(CompetitivePriceId).Append("\n");
            sb.Append("  Price: ").Append(Price).Append("\n");
            sb.Append("  Condition: ").Append(Condition).Append("\n");
            sb.Append("  Subcondition: ").Append(Subcondition).Append("\n");
            sb.Append("  BelongsToRequester: ").Append(BelongsToRequester).Append("\n");
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
            return this.Equals(input as CompetitivePriceType);
        }

        /// <summary>
        /// Returns true if CompetitivePriceType instances are equal
        /// </summary>
        /// <param name="input">Instance of CompetitivePriceType to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CompetitivePriceType input)
        {
            if (input == null)
                return false;

            return
                (
                    this.CompetitivePriceId == input.CompetitivePriceId ||
                    (this.CompetitivePriceId != null &&
                    this.CompetitivePriceId.Equals(input.CompetitivePriceId))
                ) &&
                (
                    this.Price == input.Price ||
                    (this.Price != null &&
                    this.Price.Equals(input.Price))
                ) &&
                (
                    this.Condition == input.Condition ||
                    (this.Condition != null &&
                    this.Condition.Equals(input.Condition))
                ) &&
                (
                    this.Subcondition == input.Subcondition ||
                    (this.Subcondition != null &&
                    this.Subcondition.Equals(input.Subcondition))
                ) &&
                (
                    this.BelongsToRequester == input.BelongsToRequester ||
                    (this.BelongsToRequester != null &&
                    this.BelongsToRequester.Equals(input.BelongsToRequester))
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
                if (this.CompetitivePriceId != null)
                    hashCode = hashCode * 59 + this.CompetitivePriceId.GetHashCode();
                if (this.Price != null)
                    hashCode = hashCode * 59 + this.Price.GetHashCode();
                if (this.Condition != null)
                    hashCode = hashCode * 59 + this.Condition.GetHashCode();
                if (this.Subcondition != null)
                    hashCode = hashCode * 59 + this.Subcondition.GetHashCode();
                if (this.BelongsToRequester != null)
                    hashCode = hashCode * 59 + this.BelongsToRequester.GetHashCode();
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