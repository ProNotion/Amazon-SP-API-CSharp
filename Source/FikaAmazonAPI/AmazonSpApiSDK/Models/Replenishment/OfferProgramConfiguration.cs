using System.Runtime.Serialization;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Replenishment
{
    /// <summary>
    /// The configuration of an offer in the replenishment program.
    /// </summary>
    public class OfferProgramConfiguration
    {
        /// <summary>
        /// The seller's preferences for the offer.
        /// </summary>
        [DataMember(Name = "preferences", EmitDefaultValue = false)]
        public OfferProgramConfigurationPreferences Preferences { get; set; }

        /// <summary>
        /// The promotions applied to the offer.
        /// </summary>
        [DataMember(Name = "promotions", EmitDefaultValue = false)]
        public OfferProgramConfigurationPromotions Promotions { get; set; }

        /// <summary>
        /// The replenishment program type for the offer.
        /// </summary>
        [DataMember(Name = "programType", EmitDefaultValue = false)]
        public ProgramType? ProgramType { get; set; }
    }
}
