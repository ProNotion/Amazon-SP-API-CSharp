using System.Threading;
using System.Threading.Tasks;
using FikaAmazonAPI.AmazonSpApiSDK.Models.VendorDirectFulfillmentShipping;
using FikaAmazonAPI.Parameter.VendorDirectFulfillmentShipping;
using FikaAmazonAPI.Utils;
using Microsoft.Extensions.Logging;

namespace FikaAmazonAPI.Services
{
    public class VendorDirectFulfillmentShippingService : RequestService
    {
        public VendorDirectFulfillmentShippingService(AmazonCredential amazonCredential, ILoggerFactory? loggerFactory)
            : base(amazonCredential, loggerFactory)
        {
        }

        #region Shipping labels

        public ShippingLabelList GetShippingLabels(ParameterVendorDirectFulfillmentShippingList parameter) =>
            Task.Run(() => GetShippingLabelsAsync(parameter)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<ShippingLabelList> GetShippingLabelsAsync(ParameterVendorDirectFulfillmentShippingList parameter, CancellationToken cancellationToken = default)
        {
            var queryParameters = parameter.getParameters();
            await CreateAuthorizedRequestAsync(VendorDirectFulfillmentShippingApiUrls.ShippingLabels, RestSharp.Method.Get, queryParameters, parameter: parameter, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<GetShippingLabelListResponse>(RateLimitType.VendorDirectFulfillmentShipping_GetShippingLabels, cancellationToken);
            return response?.Payload;
        }

        public TransactionReference SubmitShippingLabelRequest(SubmitShippingLabelsRequest body) =>
            Task.Run(() => SubmitShippingLabelRequestAsync(body)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<TransactionReference> SubmitShippingLabelRequestAsync(SubmitShippingLabelsRequest body, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(VendorDirectFulfillmentShippingApiUrls.ShippingLabels, RestSharp.Method.Post, postJsonObj: body, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<SubmitShippingLabelsResponse>(RateLimitType.VendorDirectFulfillmentShipping_SubmitShippingLabelRequest, cancellationToken);
            return response?.Payload;
        }

        public ShippingLabel GetShippingLabel(string purchaseOrderNumber) =>
            Task.Run(() => GetShippingLabelAsync(purchaseOrderNumber)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<ShippingLabel> GetShippingLabelAsync(string purchaseOrderNumber, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(VendorDirectFulfillmentShippingApiUrls.ShippingLabel(purchaseOrderNumber), RestSharp.Method.Get, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<GetShippingLabelResponse>(RateLimitType.VendorDirectFulfillmentShipping_GetShippingLabel, cancellationToken);
            return response?.Payload;
        }

        #endregion

        #region Shipment confirmations & status updates

        public TransactionReference SubmitShipmentConfirmations(SubmitShipmentConfirmationsRequest body) =>
            Task.Run(() => SubmitShipmentConfirmationsAsync(body)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<TransactionReference> SubmitShipmentConfirmationsAsync(SubmitShipmentConfirmationsRequest body, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(VendorDirectFulfillmentShippingApiUrls.ShipmentConfirmations, RestSharp.Method.Post, postJsonObj: body, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<SubmitShipmentConfirmationsResponse>(RateLimitType.VendorDirectFulfillmentShipping_SubmitShipmentConfirmations, cancellationToken);
            return response?.Payload;
        }

        public TransactionReference SubmitShipmentStatusUpdates(SubmitShipmentStatusUpdatesRequest body) =>
            Task.Run(() => SubmitShipmentStatusUpdatesAsync(body)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<TransactionReference> SubmitShipmentStatusUpdatesAsync(SubmitShipmentStatusUpdatesRequest body, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(VendorDirectFulfillmentShippingApiUrls.ShipmentStatusUpdates, RestSharp.Method.Post, postJsonObj: body, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<SubmitShipmentStatusUpdatesResponse>(RateLimitType.VendorDirectFulfillmentShipping_SubmitShipmentStatusUpdates, cancellationToken);
            return response?.Payload;
        }

        #endregion

        #region Customer invoices

        public CustomerInvoiceList GetCustomerInvoices(ParameterVendorDirectFulfillmentShippingList parameter) =>
            Task.Run(() => GetCustomerInvoicesAsync(parameter)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<CustomerInvoiceList> GetCustomerInvoicesAsync(ParameterVendorDirectFulfillmentShippingList parameter, CancellationToken cancellationToken = default)
        {
            var queryParameters = parameter.getParameters();
            await CreateAuthorizedRequestAsync(VendorDirectFulfillmentShippingApiUrls.CustomerInvoices, RestSharp.Method.Get, queryParameters, parameter: parameter, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<GetCustomerInvoicesResponse>(RateLimitType.VendorDirectFulfillmentShipping_GetCustomerInvoices, cancellationToken);
            return response?.Payload;
        }

        public CustomerInvoice GetCustomerInvoice(string purchaseOrderNumber) =>
            Task.Run(() => GetCustomerInvoiceAsync(purchaseOrderNumber)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<CustomerInvoice> GetCustomerInvoiceAsync(string purchaseOrderNumber, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(VendorDirectFulfillmentShippingApiUrls.CustomerInvoice(purchaseOrderNumber), RestSharp.Method.Get, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<GetCustomerInvoiceResponse>(RateLimitType.VendorDirectFulfillmentShipping_GetCustomerInvoice, cancellationToken);
            return response?.Payload;
        }

        #endregion

        #region Packing slips

        public PackingSlipList GetPackingSlips(ParameterVendorDirectFulfillmentShippingList parameter) =>
            Task.Run(() => GetPackingSlipsAsync(parameter)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<PackingSlipList> GetPackingSlipsAsync(ParameterVendorDirectFulfillmentShippingList parameter, CancellationToken cancellationToken = default)
        {
            var queryParameters = parameter.getParameters();
            await CreateAuthorizedRequestAsync(VendorDirectFulfillmentShippingApiUrls.PackingSlips, RestSharp.Method.Get, queryParameters, parameter: parameter, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<GetPackingSlipListResponse>(RateLimitType.VendorDirectFulfillmentShipping_GetPackingSlips, cancellationToken);
            return response?.Payload;
        }

        public PackingSlip GetPackingSlip(string purchaseOrderNumber) =>
            Task.Run(() => GetPackingSlipAsync(purchaseOrderNumber)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<PackingSlip> GetPackingSlipAsync(string purchaseOrderNumber, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(VendorDirectFulfillmentShippingApiUrls.PackingSlip(purchaseOrderNumber), RestSharp.Method.Get, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<GetPackingSlipResponse>(RateLimitType.VendorDirectFulfillmentShipping_GetPackingSlip, cancellationToken);
            return response?.Payload;
        }

        #endregion
    }
}
