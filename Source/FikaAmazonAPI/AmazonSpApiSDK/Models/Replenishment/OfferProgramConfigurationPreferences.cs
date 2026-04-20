using System.Runtime.Serialization;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Replenishment
{
    /// <summary>
    /// The seller's preferences for the replenishment program offer.
    /// </summary>
    public class OfferProgramConfigurationPreferences
    {
        /// <summary>
        /// The seller's preference for automatic enrollment in the replenishment program.
        /// </summary>
        [DataMember(Name = "automationStatus", EmitDefaultValue = false)]
        public AutoEnrollmentPreference? AutomationStatus { get; set; }
    }
}
