using FikaAmazonAPI.AmazonSpApiSDK.Models.VendorShipments;
using FikaAmazonAPI.Parameter.VendorShipments;

namespace FikaAmazonAPI.SampleCode;

public class VendorShipmentsSample
{
    AmazonConnection amazonConnection;

    public VendorShipmentsSample(AmazonConnection amazonConnection)
    {
        this.amazonConnection = amazonConnection;
    }

    public void SubmitShipmentConfirmations()
    {
        var txn = amazonConnection.VendorShipments.SubmitShipmentConfirmations(new SubmitShipmentConfirmationsRequest
        {
            ShipmentConfirmations = new List<ShipmentConfirmation>
            {
                new() { ShipmentIdentifier = "SHIPMENT_ID" },
            },
        });
    }

    public void SubmitShipments()
    {
        var txn = amazonConnection.VendorShipments.SubmitShipments(new SubmitShipments
        {
            Shipments = new List<Shipment>
            {
                new() { VendorShipmentIdentifier = "VENDOR_SHIPMENT_ID" },
            },
        });
    }

    public void GetShipmentDetails()
    {
        var details = amazonConnection.VendorShipments.GetShipmentDetails(new ParameterGetShipmentDetails
        {
            Limit = 10,
            SortOrder = "DESC",
            CreatedAfter = DateTime.UtcNow.AddDays(-7),
            CreatedBefore = DateTime.UtcNow,
        });

        var shipments = details?.Shipments;
        var nextToken = details?.Pagination?.NextToken; // page manually via NextToken
    }

    public void GetShipmentLabels()
    {
        var labels = amazonConnection.VendorShipments.GetShipmentLabels(new ParameterGetShipmentLabels
        {
            Limit = 10,
            SortOrder = "DESC",
        });
    }
}
