using System.Runtime.Serialization;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Replenishment
{
    /// <summary>
    /// The promotions applied to a replenishment program offer.
    /// </summary>
    public class OfferProgramConfigurationPromotions
    {
        /// <summary>
        /// The seller-funded base discount percentage applied to the offer.
        /// </summary>
        [DataMember(Name = "sellerFundedBaseDiscount", EmitDefaultValue = false)]
        public decimal? SellerFundedBaseDiscount { get; set; }

        /// <summary>
        /// The seller-funded tiered discount percentage applied to the offer.
        /// </summary>
        [DataMember(Name = "sellerFundedTieredDiscount", EmitDefaultValue = false)]
        public decimal? SellerFundedTieredDiscount { get; set; }
    }
}
