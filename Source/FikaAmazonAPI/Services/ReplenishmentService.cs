using FikaAmazonAPI.AmazonSpApiSDK.Models.Replenishment;
using FikaAmazonAPI.Utils;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using static FikaAmazonAPI.Utils.Constants;

namespace FikaAmazonAPI.Services
{
    /// <summary>
    /// Provides access to the Amazon Replenishment API (v2022-11-07).
    /// </summary>
    public class ReplenishmentService : RequestService
    {
        public ReplenishmentService(AmazonCredential amazonCredential, ILoggerFactory? loggerFactory)
            : base(amazonCredential, loggerFactory)
        {
        }

        /// <summary>
        /// Returns aggregated replenishment program metrics for a selling partner's entire account.
        /// </summary>
        /// <param name="request">The request parameters including marketplace, time interval, and metrics to retrieve.</param>
        /// <returns>A <see cref="GetSellingPartnerMetricsResponse"/> containing the requested metrics.</returns>
        public GetSellingPartnerMetricsResponse GetSellingPartnerMetrics(GetSellingPartnerMetricsRequest request) =>
            Task.Run(() => GetSellingPartnerMetricsAsync(request)).ConfigureAwait(false).GetAwaiter().GetResult();

        /// <summary>
        /// Returns aggregated replenishment program metrics for a selling partner's entire account asynchronously.
        /// </summary>
        /// <param name="request">The request parameters including marketplace, time interval, and metrics to retrieve.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the request.</param>
        /// <returns>A task that resolves to a <see cref="GetSellingPartnerMetricsResponse"/> containing the requested metrics.</returns>
        public async Task<GetSellingPartnerMetricsResponse> GetSellingPartnerMetricsAsync(
            GetSellingPartnerMetricsRequest request, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(ReplenishmentApi.GetSellingPartnerMetrics, RestSharp.Method.Post,
                postJsonObj: request, cancellationToken: cancellationToken);

            return await ExecuteRequestAsync<GetSellingPartnerMetricsResponse>(
                RateLimitType.Replenishment_GetSellingPartnerMetrics, cancellationToken);
        }

        /// <summary>
        /// Returns replenishment program metrics for offers, aggregated at the ASIN level.
        /// </summary>
        /// <param name="request">The request parameters including filters, pagination, and sort options.</param>
        /// <returns>A <see cref="ListOfferMetricsResponse"/> containing offer-level metrics.</returns>
        public ListOfferMetricsResponse ListOfferMetrics(ListOfferMetricsRequest request) =>
            Task.Run(() => ListOfferMetricsAsync(request)).ConfigureAwait(false).GetAwaiter().GetResult();

        /// <summary>
        /// Returns replenishment program metrics for offers, aggregated at the ASIN level, asynchronously.
        /// </summary>
        /// <param name="request">The request parameters including filters, pagination, and sort options.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the request.</param>
        /// <returns>A task that resolves to a <see cref="ListOfferMetricsResponse"/> containing offer-level metrics.</returns>
        public async Task<ListOfferMetricsResponse> ListOfferMetricsAsync(
            ListOfferMetricsRequest request, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(ReplenishmentApi.ListOfferMetrics, RestSharp.Method.Post,
                postJsonObj: request, cancellationToken: cancellationToken);

            return await ExecuteRequestAsync<ListOfferMetricsResponse>(
                RateLimitType.Replenishment_ListOfferMetrics, cancellationToken);
        }

        /// <summary>
        /// Returns a selling partner's replenishment program offers.
        /// </summary>
        /// <param name="request">The request parameters including filters, pagination, and sort options.</param>
        /// <returns>A <see cref="ListOffersResponse"/> containing the seller's replenishment offers.</returns>
        public ListOffersResponse ListOffers(ListOffersRequest request) =>
            Task.Run(() => ListOffersAsync(request)).ConfigureAwait(false).GetAwaiter().GetResult();

        /// <summary>
        /// Returns a selling partner's replenishment program offers asynchronously.
        /// </summary>
        /// <param name="request">The request parameters including filters, pagination, and sort options.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the request.</param>
        /// <returns>A task that resolves to a <see cref="ListOffersResponse"/> containing the seller's replenishment offers.</returns>
        public async Task<ListOffersResponse> ListOffersAsync(
            ListOffersRequest request, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(ReplenishmentApi.ListOffers, RestSharp.Method.Post,
                postJsonObj: request, cancellationToken: cancellationToken);

            return await ExecuteRequestAsync<ListOffersResponse>(
                RateLimitType.Replenishment_ListOffers, cancellationToken);
        }
    }
}
