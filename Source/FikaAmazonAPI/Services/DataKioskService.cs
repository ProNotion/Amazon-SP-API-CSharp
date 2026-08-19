using System.Threading;
using System.Threading.Tasks;
using FikaAmazonAPI.AmazonSpApiSDK.Models.DataKiosk;
using FikaAmazonAPI.Parameter.DataKiosk;
using FikaAmazonAPI.Utils;
using Microsoft.Extensions.Logging;

namespace FikaAmazonAPI.Services
{
    public class DataKioskService : RequestService
    {
        public DataKioskService(AmazonCredential amazonCredential, ILoggerFactory? loggerFactory)
            : base(amazonCredential, loggerFactory)
        {
        }

        #region GetQueries

        public GetQueriesResponse GetQueries(ParameterGetQueries parameterGetQueries) =>
            Task.Run(() => GetQueriesAsync(parameterGetQueries)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<GetQueriesResponse> GetQueriesAsync(ParameterGetQueries parameterGetQueries, CancellationToken cancellationToken = default)
        {
            var queryParameters = parameterGetQueries.getParameters();
            await CreateAuthorizedRequestAsync(DataKioskApiUrls.Queries, RestSharp.Method.Get, queryParameters, parameter: parameterGetQueries, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<GetQueriesResponse>(RateLimitType.DataKiosk_GetQueries, cancellationToken);
        }

        #endregion

        #region CreateQuery

        public CreateQueryResponse CreateQuery(CreateQuerySpecification createQuerySpecification) =>
            Task.Run(() => CreateQueryAsync(createQuerySpecification)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<CreateQueryResponse> CreateQueryAsync(CreateQuerySpecification createQuerySpecification, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(DataKioskApiUrls.Queries, RestSharp.Method.Post, postJsonObj: createQuerySpecification, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<CreateQueryResponse>(RateLimitType.DataKiosk_CreateQuery, cancellationToken);
        }

        #endregion

        #region GetQuery

        public Query GetQuery(string queryId) =>
            Task.Run(() => GetQueryAsync(queryId)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<Query> GetQueryAsync(string queryId, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(DataKioskApiUrls.Query(queryId), RestSharp.Method.Get, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<Query>(RateLimitType.DataKiosk_GetQuery, cancellationToken);
        }

        #endregion

        #region CancelQuery

        public void CancelQuery(string queryId) =>
            Task.Run(() => CancelQueryAsync(queryId)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task CancelQueryAsync(string queryId, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(DataKioskApiUrls.Query(queryId), RestSharp.Method.Delete, cancellationToken: cancellationToken);
            await ExecuteRequestAsync<object>(RateLimitType.DataKiosk_CancelQuery, cancellationToken);
        }

        #endregion

        #region GetDocument

        public GetDocumentResponse GetDocument(string documentId) =>
            Task.Run(() => GetDocumentAsync(documentId)).ConfigureAwait(false).GetAwaiter().GetResult();

        public async Task<GetDocumentResponse> GetDocumentAsync(string documentId, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(DataKioskApiUrls.Document(documentId), RestSharp.Method.Get, cancellationToken: cancellationToken);
            return await ExecuteRequestAsync<GetDocumentResponse>(RateLimitType.DataKiosk_GetDocument, cancellationToken);
        }

        #endregion
    }
}
