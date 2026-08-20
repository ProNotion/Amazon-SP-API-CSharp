namespace FikaAmazonAPI.Parameter.ExternalFulfillmentShipment
{
    /// <summary>
    /// The operation to perform when processing a shipment (processShipment).
    /// The enum member names match the exact values expected by the SP-API.
    /// </summary>
    public enum ProcessShipmentOperation
    {
        /// <summary>Confirm the shipment.</summary>
        CONFIRM,

        /// <summary>Reject the shipment.</summary>
        REJECT
    }

    /// <summary>
    /// The operation to perform when generating shipping labels (generateShipLabels).
    /// The enum member names match the exact values expected by the SP-API.
    /// </summary>
    public enum GenerateShipLabelsOperation
    {
        /// <summary>Generate a new shipping label for the first time.</summary>
        GENERATE,

        /// <summary>Regenerate an existing shipping label.</summary>
        REGENERATE
    }
}
