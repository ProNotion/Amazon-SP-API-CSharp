using FikaAmazonAPI.AmazonSpApiSDK.Models.VendorInvoices;

namespace FikaAmazonAPI.SampleCode;

public class VendorInvoicesSample
{
    AmazonConnection amazonConnection;

    public VendorInvoicesSample(AmazonConnection amazonConnection)
    {
        this.amazonConnection = amazonConnection;
    }

    public void SubmitInvoices()
    {
        var request = new SubmitInvoicesRequest
        {
            Invoices = new List<Invoice>
            {
                new()
                {
                    Id = "INV-0001",
                    ReferenceNumber = "PO-123456",
                    RemitToParty = new PartyIdentification { PartyId = "REMIT_TO_PARTY_ID" },
                    ShipFromParty = new PartyIdentification { PartyId = "SHIP_FROM_PARTY_ID" },
                    ShipToParty = new PartyIdentification { PartyId = "SHIP_TO_PARTY_ID" },
                    InvoiceTotal = new Money { CurrencyCode = "USD", Amount = "100.00" },
                },
            },
        };

        // Returns a TransactionId that can be polled via the Vendor Transaction Status API.
        var result = amazonConnection.VendorInvoices.SubmitInvoices(request);
    }
}
