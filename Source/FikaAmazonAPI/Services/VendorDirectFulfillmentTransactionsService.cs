using System.Threading;
using System.Threading.Tasks;
using FikaAmazonAPI.AmazonSpApiSDK.Models.VendorDirectFulfillmentTransactions;
using FikaAmazonAPI.Utils;
using Microsoft.Extensions.Logging;

namespace FikaAmazonAPI.Services
{
    public class VendorDirectFulfillmentTransactionsService : RequestService
    {
        public VendorDirectFulfillmentTransactionsService(AmazonCredential amazonCredential, ILoggerFactory? loggerFactory)
            : base(amazonCredential, loggerFactory)
        {
        }

        public TransactionStatus GetTransactionStatus(string transactionId) =>
            Task.Run(() => GetTransactionStatusAsync(transactionId)).ConfigureAwait(false)
                .GetAwaiter().GetResult();

        public async Task<TransactionStatus> GetTransactionStatusAsync(string transactionId, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(VendorDirectFulfillmentTransactionsApiUrls.GetTransactionStatus(transactionId), RestSharp.Method.Get, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<GetTransactionResponse>(RateLimitType.VendorDirectFulfillmentTransactions_GetTransactionStatus, cancellationToken);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
    }
}
