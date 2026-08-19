using FikaAmazonAPI.AmazonSpApiSDK.Models.VendorDirectFulfillmentTransactions;

namespace FikaAmazonAPI.SampleCode;

public class VendorDirectFulfillmentTransactionsSample
{
    AmazonConnection amazonConnection;

    public VendorDirectFulfillmentTransactionsSample(AmazonConnection amazonConnection)
    {
        this.amazonConnection = amazonConnection;
    }

    public void GetTransactionStatus()
    {
        // Poll the status of a transaction returned by any direct-fulfillment submit
        // operation (e.g. SubmitInvoice, SubmitInventoryUpdate, submitShipmentConfirmations).
        var status = amazonConnection.VendorDirectFulfillmentTransactions.GetTransactionStatus("TRANSACTION_ID");

        var transaction = status?._TransactionStatus;
        if (transaction != null && transaction.Status == Transaction.StatusEnum.Failure)
        {
            var errors = transaction.Errors;
        }
    }
}
