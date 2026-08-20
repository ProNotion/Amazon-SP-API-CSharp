using System.Threading;
using System.Threading.Tasks;
using FikaAmazonAPI.AmazonSpApiSDK.Models.VendorInvoices;
using FikaAmazonAPI.Utils;
using Microsoft.Extensions.Logging;

namespace FikaAmazonAPI.Services
{
    public class VendorInvoicesService : RequestService
    {
        public VendorInvoicesService(AmazonCredential amazonCredential, ILoggerFactory? loggerFactory)
            : base(amazonCredential, loggerFactory)
        {
        }

        public TransactionId SubmitInvoices(SubmitInvoicesRequest submitInvoicesRequest) =>
            Task.Run(() => SubmitInvoicesAsync(submitInvoicesRequest)).ConfigureAwait(false)
                .GetAwaiter().GetResult();

        public async Task<TransactionId> SubmitInvoicesAsync(SubmitInvoicesRequest submitInvoicesRequest, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(VendorInvoicesApiUrls.SubmitInvoices, RestSharp.Method.Post, postJsonObj: submitInvoicesRequest, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<SubmitInvoicesResponse>(RateLimitType.VendorInvoices_SubmitInvoices, cancellationToken);
            return response?.Payload;
        }
    }
}
