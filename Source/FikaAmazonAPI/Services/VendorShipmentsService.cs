using System.Threading;
using System.Threading.Tasks;
using FikaAmazonAPI.AmazonSpApiSDK.Models.VendorShipments;
using FikaAmazonAPI.Parameter.VendorShipments;
using FikaAmazonAPI.Utils;
using Microsoft.Extensions.Logging;

namespace FikaAmazonAPI.Services
{
    public class VendorShipmentsService : RequestService
    {
        public VendorShipmentsService(AmazonCredential amazonCredential, ILoggerFactory? loggerFactory)
            : base(amazonCredential, loggerFactory)
        {
        }

        #region SubmitShipmentConfirmations

        public TransactionReference SubmitShipmentConfirmations(SubmitShipmentConfirmationsRequest submitShipmentConfirmationsRequest) =>
            Task.Run(() => SubmitShipmentConfirmationsAsync(submitShipmentConfirmationsRequest)).ConfigureAwait(false)
                .GetAwaiter().GetResult();

        public async Task<TransactionReference> SubmitShipmentConfirmationsAsync(SubmitShipmentConfirmationsRequest submitShipmentConfirmationsRequest, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(VendorShipmentsApiUrls.ShipmentConfirmations, RestSharp.Method.Post, postJsonObj: submitShipmentConfirmationsRequest, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<SubmitShipmentConfirmationsResponse>(RateLimitType.VendorShipments_SubmitShipmentConfirmations, cancellationToken);
            return response?.Payload;
        }

        #endregion

        #region SubmitShipments

        public TransactionReference SubmitShipments(SubmitShipments submitShipments) =>
            Task.Run(() => SubmitShipmentsAsync(submitShipments)).ConfigureAwait(false)
                .GetAwaiter().GetResult();

        public async Task<TransactionReference> SubmitShipmentsAsync(SubmitShipments submitShipments, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(VendorShipmentsApiUrls.Shipments, RestSharp.Method.Post, postJsonObj: submitShipments, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<SubmitShipmentConfirmationsResponse>(RateLimitType.VendorShipments_SubmitShipments, cancellationToken);
            return response?.Payload;
        }

        #endregion

        #region GetShipmentDetails

        public ShipmentDetails GetShipmentDetails(ParameterGetShipmentDetails parameterGetShipmentDetails) =>
            Task.Run(() => GetShipmentDetailsAsync(parameterGetShipmentDetails)).ConfigureAwait(false)
                .GetAwaiter().GetResult();

        public async Task<ShipmentDetails> GetShipmentDetailsAsync(ParameterGetShipmentDetails parameterGetShipmentDetails, CancellationToken cancellationToken = default)
        {
            var queryParameters = parameterGetShipmentDetails.getParameters();
            await CreateAuthorizedRequestAsync(VendorShipmentsApiUrls.Shipments, RestSharp.Method.Get, queryParameters, parameter: parameterGetShipmentDetails, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<GetShipmentDetailsResponse>(RateLimitType.VendorShipments_GetShipmentDetails, cancellationToken);
            return response?.Payload;
        }

        #endregion

        #region GetShipmentLabels

        public TransportationLabels GetShipmentLabels(ParameterGetShipmentLabels parameterGetShipmentLabels) =>
            Task.Run(() => GetShipmentLabelsAsync(parameterGetShipmentLabels)).ConfigureAwait(false)
                .GetAwaiter().GetResult();

        public async Task<TransportationLabels> GetShipmentLabelsAsync(ParameterGetShipmentLabels parameterGetShipmentLabels, CancellationToken cancellationToken = default)
        {
            var queryParameters = parameterGetShipmentLabels.getParameters();
            await CreateAuthorizedRequestAsync(VendorShipmentsApiUrls.TransportLabels, RestSharp.Method.Get, queryParameters, parameter: parameterGetShipmentLabels, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<GetShipmentLabels>(RateLimitType.VendorShipments_GetShipmentLabels, cancellationToken);
            return response?.Payload;
        }

        #endregion
    }
}
