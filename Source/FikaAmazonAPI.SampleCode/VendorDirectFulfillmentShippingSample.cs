using FikaAmazonAPI.AmazonSpApiSDK.Models.VendorDirectFulfillmentShipping;
using FikaAmazonAPI.Parameter.VendorDirectFulfillmentShipping;

namespace FikaAmazonAPI.SampleCode;

public class VendorDirectFulfillmentShippingSample
{
    AmazonConnection amazonConnection;

    public VendorDirectFulfillmentShippingSample(AmazonConnection amazonConnection)
    {
        this.amazonConnection = amazonConnection;
    }

    public void GetShippingLabels()
    {
        var labels = amazonConnection.VendorDirectFulfillmentShipping.GetShippingLabels(new ParameterVendorDirectFulfillmentShippingList
        {
            Limit = 10,
            SortOrder = "ASC",
            CreatedAfter = DateTime.UtcNow.AddDays(-7),
            CreatedBefore = DateTime.UtcNow,
        });

        var nextToken = labels?.Pagination?.NextToken;
    }

    public void GetShippingLabel()
    {
        var label = amazonConnection.VendorDirectFulfillmentShipping.GetShippingLabel("PURCHASE_ORDER_NUMBER");
    }

    public void SubmitShippingLabelRequest()
    {
        var txn = amazonConnection.VendorDirectFulfillmentShipping.SubmitShippingLabelRequest(new SubmitShippingLabelsRequest
        {
            ShippingLabelRequests = new List<ShippingLabelRequest>
            {
                new() { PurchaseOrderNumber = "PURCHASE_ORDER_NUMBER" },
            },
        });
    }

    public void SubmitShipmentConfirmations()
    {
        var txn = amazonConnection.VendorDirectFulfillmentShipping.SubmitShipmentConfirmations(new SubmitShipmentConfirmationsRequest
        {
            ShipmentConfirmations = new List<ShipmentConfirmation>
            {
                new() { PurchaseOrderNumber = "PURCHASE_ORDER_NUMBER" },
            },
        });
    }

    public void SubmitShipmentStatusUpdates()
    {
        var txn = amazonConnection.VendorDirectFulfillmentShipping.SubmitShipmentStatusUpdates(new SubmitShipmentStatusUpdatesRequest
        {
            ShipmentStatusUpdates = new List<ShipmentStatusUpdate>
            {
                new() { PurchaseOrderNumber = "PURCHASE_ORDER_NUMBER" },
            },
        });
    }

    public void GetCustomerInvoices()
    {
        var invoices = amazonConnection.VendorDirectFulfillmentShipping.GetCustomerInvoices(new ParameterVendorDirectFulfillmentShippingList { Limit = 10 });
    }

    public void GetCustomerInvoice()
    {
        var invoice = amazonConnection.VendorDirectFulfillmentShipping.GetCustomerInvoice("PURCHASE_ORDER_NUMBER");
    }

    public void GetPackingSlips()
    {
        var slips = amazonConnection.VendorDirectFulfillmentShipping.GetPackingSlips(new ParameterVendorDirectFulfillmentShippingList { Limit = 10 });
    }

    public void GetPackingSlip()
    {
        var slip = amazonConnection.VendorDirectFulfillmentShipping.GetPackingSlip("PURCHASE_ORDER_NUMBER");
    }
}
