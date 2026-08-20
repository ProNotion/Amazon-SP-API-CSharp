using FikaAmazonAPI.AmazonSpApiSDK.Models.VendorDirectFulfillmentPayments;

namespace FikaAmazonAPI.SampleCode;

public class VendorDirectFulfillmentPaymentsSample
{
    AmazonConnection amazonConnection;

    public VendorDirectFulfillmentPaymentsSample(AmazonConnection amazonConnection)
    {
        this.amazonConnection = amazonConnection;
    }

    public void SubmitInvoice()
    {
        var request = new SubmitInvoiceRequest
        {
            Invoices = new List<InvoiceDetail>
            {
                new()
                {
                    InvoiceNumber = "INV-0001",
                    InvoiceDate = DateTime.UtcNow.ToString("o"),
                    RemitToParty = new PartyIdentification { PartyId = "REMIT_TO_PARTY_ID" },
                    ShipFromParty = new PartyIdentification { PartyId = "SHIP_FROM_PARTY_ID" },
                    BillToParty = new PartyIdentification { PartyId = "BILL_TO_PARTY_ID" },
                    InvoiceTotal = new Money { CurrencyCode = "USD", Amount = "100.00" },
                    Items = new List<InvoiceItem>
                    {
                        new()
                        {
                            ItemSequenceNumber = "1",
                            VendorProductIdentifier = "VENDOR_SKU",
                            InvoicedQuantity = new ItemQuantity { Amount = 2, UnitOfMeasure = "Each" },
                            NetCost = new Money { CurrencyCode = "USD", Amount = "50.00" },
                            PurchaseOrderNumber = "PO-123456",
                            TaxDetails = new List<TaxDetail>
                            {
                                new()
                                {
                                    TaxType = TaxDetail.TaxTypeEnum.VAT,
                                    TaxRate = "0.20",
                                    TaxAmount = new Money { CurrencyCode = "USD", Amount = "20.00" },
                                },
                            },
                        },
                    },
                },
            },
        };

        // Returns a TransactionReference whose TransactionId can be polled via the
        // Vendor Transaction Status API (amazonConnection.VendorTransactionStatus).
        var result = amazonConnection.VendorDirectFulfillmentPayments.SubmitInvoice(request);
    }
}
