using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

using FikaAmazonAPI.AmazonSpApiSDK.Models.ExternalFulfillmentShipment;
using FikaAmazonAPI.AmazonSpApiSDK.Models.Token;
using FikaAmazonAPI.Parameter.ExternalFulfillmentShipment;
using FikaAmazonAPI.Utils;

using Microsoft.Extensions.Logging;

using Method = FikaAmazonAPI.RestSharp.Method;

namespace FikaAmazonAPI.Services
{
    public class ExternalFulfillmentShipmentService : RequestService
    {
        private const string StatusShipped = "SHIPPED";

        public ExternalFulfillmentShipmentService(AmazonCredential amazonCredential, ILoggerFactory loggerFactory) : base(amazonCredential, loggerFactory)
        {
        }

        #region GetShipments

        public List<Shipment> GetShipments(ParameterGetShipments parameterGetShipments) =>
            Task.Run(() => GetShipmentsAsync(parameterGetShipments)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<List<Shipment>> GetShipmentsAsync(ParameterGetShipments parameterGetShipments, CancellationToken ct = default)
        {
            if (parameterGetShipments.Status == null)
                throw new InvalidDataException("Status is required");

            if (parameterGetShipments.MaxResults.HasValue &&
                (parameterGetShipments.MaxResults.Value < 1 || parameterGetShipments.MaxResults.Value > 100))
                throw new InvalidDataException("MaxResults must be between 1 and 100");

            var parameter = parameterGetShipments.getParameters();
            await CreateAuthorizedRequestAsync(ExternalFulfillmentShipmentApiUrls.Shipments, Method.Get, parameter, null, CacheTokenData.TokenDataType.Normal, null, ct);

            List<Shipment> list = new List<Shipment>();

            var response = await ExecuteRequestAsync<ShipmentsResponse>(RateLimitType.ExternalFulfillmentShipment_GetShipments, ct);
            if (response?.Shipments != null)
                list.AddRange(response.Shipments);

            // Surface the token on the parameter object so callers can continue manually
            // via GetShipmentsByNextToken, even when MaxNumberOfPages stops the loop below.
            parameterGetShipments.PaginationToken = response?.Pagination?.NextToken;

            var totalPages = 1;
            while (!string.IsNullOrEmpty(parameterGetShipments.PaginationToken) &&
                (!parameterGetShipments.MaxNumberOfPages.HasValue || totalPages < parameterGetShipments.MaxNumberOfPages.Value))
            {
                var getShipmentsNextPage = await GetShipmentsByNextTokenAsync(parameterGetShipments, ct);
                if (getShipmentsNextPage?.Shipments != null)
                    list.AddRange(getShipmentsNextPage.Shipments);
                parameterGetShipments.PaginationToken = getShipmentsNextPage?.Pagination?.NextToken;
                totalPages++;
            }

            return list;
        }

        public ShipmentsResponse GetShipmentsByNextToken(ParameterGetShipments parameterGetShipments) =>
            Task.Run(() => GetShipmentsByNextTokenAsync(parameterGetShipments)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<ShipmentsResponse> GetShipmentsByNextTokenAsync(ParameterGetShipments parameterGetShipments, CancellationToken ct = default)
        {
            var parameter = parameterGetShipments.getParameters();

            await CreateAuthorizedRequestAsync(ExternalFulfillmentShipmentApiUrls.Shipments, Method.Get, parameter, null, CacheTokenData.TokenDataType.Normal, null, ct);
            return await ExecuteRequestAsync<ShipmentsResponse>(RateLimitType.ExternalFulfillmentShipment_GetShipments, ct);
        }

        #endregion

        public Shipment GetShipment(string shipmentId) =>
            Task.Run(() => GetShipmentAsync(shipmentId)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<Shipment> GetShipmentAsync(string shipmentId, CancellationToken ct = default)
        {
            await CreateAuthorizedRequestAsync(ExternalFulfillmentShipmentApiUrls.Shipment(shipmentId), Method.Get, null, null, CacheTokenData.TokenDataType.Normal, null, ct);

            return await ExecuteRequestAsync<Shipment>(RateLimitType.ExternalFulfillmentShipment_GetShipment, ct);
        }

        public void ProcessShipment(string shipmentId, ProcessShipmentOperation operation, ShipmentAcknowledgementRequest body) =>
            Task.Run(() => ProcessShipmentAsync(shipmentId, operation, body)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task ProcessShipmentAsync(string shipmentId, ProcessShipmentOperation operation, ShipmentAcknowledgementRequest body, CancellationToken ct = default)
        {
            var query = new List<KeyValuePair<string, string>> { new KeyValuePair<string, string>("operation", operation.ToString()) };

            await CreateAuthorizedRequestAsync(ExternalFulfillmentShipmentApiUrls.Shipment(shipmentId), Method.Post, query, body, CacheTokenData.TokenDataType.Normal, null, ct);
            await ExecuteRequestAsync<object>(RateLimitType.ExternalFulfillmentShipment_ProcessShipment, ct);
        }

        public void CreatePackages(string shipmentId, Packages body) =>
            Task.Run(() => CreatePackagesAsync(shipmentId, body)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task CreatePackagesAsync(string shipmentId, Packages body, CancellationToken ct = default)
        {
            await CreateAuthorizedRequestAsync(ExternalFulfillmentShipmentApiUrls.Packages(shipmentId), Method.Post, null, body, CacheTokenData.TokenDataType.Normal, null, ct);
            await ExecuteRequestAsync<object>(RateLimitType.ExternalFulfillmentShipment_CreatePackages, ct);
        }

        public void UpdatePackage(string shipmentId, string packageId, Package body) =>
            Task.Run(() => UpdatePackageAsync(shipmentId, packageId, body)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task UpdatePackageAsync(string shipmentId, string packageId, Package body, CancellationToken ct = default)
        {
            await CreateAuthorizedRequestAsync(ExternalFulfillmentShipmentApiUrls.Package(shipmentId, packageId), Method.Put, null, body, CacheTokenData.TokenDataType.Normal, null, ct);
            await ExecuteRequestAsync<object>(RateLimitType.ExternalFulfillmentShipment_UpdatePackage, ct);
        }

        public ShippingOptionsResponse RetrieveShippingOptions(string shipmentId, string packageId) =>
            Task.Run(() => RetrieveShippingOptionsAsync(shipmentId, packageId)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<ShippingOptionsResponse> RetrieveShippingOptionsAsync(string shipmentId, string packageId, CancellationToken ct = default)
        {
            var query = new List<KeyValuePair<string, string>> { new KeyValuePair<string, string>("packageId", packageId) };
            await CreateAuthorizedRequestAsync(ExternalFulfillmentShipmentApiUrls.ShippingOptions(shipmentId), Method.Get, query, null, CacheTokenData.TokenDataType.Normal, null, ct);

            return await ExecuteRequestAsync<ShippingOptionsResponse>(RateLimitType.ExternalFulfillmentShipment_RetrieveShippingOptions, ct);
        }

        public ShipLabelsResponse GenerateShipLabels(string shipmentId, GenerateShipLabelsOperation operation, ShipLabelsInput body, string shippingOptionId = null) =>
            Task.Run(() => GenerateShipLabelsAsync(shipmentId, operation, body, shippingOptionId)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<ShipLabelsResponse> GenerateShipLabelsAsync(string shipmentId, GenerateShipLabelsOperation operation, ShipLabelsInput body, string shippingOptionId = null, CancellationToken ct = default)
        {
            var query = new List<KeyValuePair<string, string>> { new KeyValuePair<string, string>("operation", operation.ToString()) };

            if (!string.IsNullOrEmpty(shippingOptionId))
                query.Add(new KeyValuePair<string, string>("shippingOptionId", shippingOptionId));

            await CreateAuthorizedRequestAsync(ExternalFulfillmentShipmentApiUrls.ShipLabels(shipmentId), Method.Put, query, body, CacheTokenData.TokenDataType.Normal, null, ct);
            return await ExecuteRequestAsync<ShipLabelsResponse>(RateLimitType.ExternalFulfillmentShipment_GenerateShipLabels, ct);
        }

        public void GenerateInvoice(string shipmentId) =>
            Task.Run(() => GenerateInvoiceAsync(shipmentId)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task GenerateInvoiceAsync(string shipmentId, CancellationToken ct = default)
        {
            await CreateAuthorizedRequestAsync(ExternalFulfillmentShipmentApiUrls.Invoice(shipmentId), Method.Post, null, null, CacheTokenData.TokenDataType.Normal, null, ct);
            await ExecuteRequestAsync<object>(RateLimitType.ExternalFulfillmentShipment_GenerateInvoice, ct);
        }

        public InvoiceResponse RetrieveInvoice(string shipmentId) =>
            Task.Run(() => RetrieveInvoiceAsync(shipmentId)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<InvoiceResponse> RetrieveInvoiceAsync(string shipmentId, CancellationToken ct = default)
        {
            await CreateAuthorizedRequestAsync(ExternalFulfillmentShipmentApiUrls.Invoice(shipmentId), Method.Get, null, null, CacheTokenData.TokenDataType.Normal, null, ct);
            return await ExecuteRequestAsync<InvoiceResponse>(RateLimitType.ExternalFulfillmentShipment_RetrieveInvoice, ct);
        }

        public void UpdatePackageStatusShipped(string shipmentId, string packageId, PackageDeliveryStatus body) =>
            Task.Run(() => UpdatePackageStatusShippedAsync(shipmentId, packageId, body)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task UpdatePackageStatusShippedAsync(string shipmentId, string packageId, PackageDeliveryStatus body, CancellationToken ct = default)
        {
            var query = new List<KeyValuePair<string, string>> { new KeyValuePair<string, string>("status", StatusShipped) };
            await CreateAuthorizedRequestAsync(ExternalFulfillmentShipmentApiUrls.Package(shipmentId, packageId), Method.Patch, query, body, CacheTokenData.TokenDataType.Normal, null, ct);
            await ExecuteRequestAsync<object>(RateLimitType.ExternalFulfillmentShipment_UpdatePackageStatus, ct);
        }
    }
}
