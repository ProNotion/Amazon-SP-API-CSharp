using System.Threading;
using System.Threading.Tasks;
using FikaAmazonAPI.AmazonSpApiSDK.Models.VendorDirectFulfillmentPayments;
using FikaAmazonAPI.Utils;
using Microsoft.Extensions.Logging;

namespace FikaAmazonAPI.Services
{
    public class VendorDirectFulfillmentPaymentsService : RequestService
    {
        public VendorDirectFulfillmentPaymentsService(AmazonCredential amazonCredential, ILoggerFactory? loggerFactory)
            : base(amazonCredential, loggerFactory)
        {
        }

        public TransactionReference SubmitInvoice(SubmitInvoiceRequest submitInvoiceRequest) =>
            Task.Run(() => SubmitInvoiceAsync(submitInvoiceRequest)).ConfigureAwait(false)
                .GetAwaiter().GetResult();

        public async Task<TransactionReference> SubmitInvoiceAsync(SubmitInvoiceRequest submitInvoiceRequest, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(VendorDirectFulfillmentPaymentsApiUrls.SubmitInvoice, RestSharp.Method.Post, postJsonObj: submitInvoiceRequest, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<SubmitInvoiceResponse>(RateLimitType.VendorDirectFulfillmentPayments_SubmitInvoice, cancellationToken);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
    }
}
