using FikaAmazonAPI.AmazonSpApiSDK.Models.DataKiosk;
using FikaAmazonAPI.Parameter.DataKiosk;

namespace FikaAmazonAPI.SampleCode;

public class DataKioskSample
{
    AmazonConnection amazonConnection;

    public DataKioskSample(AmazonConnection amazonConnection)
    {
        this.amazonConnection = amazonConnection;
    }

    public void CreateQuery()
    {
        // Data Kiosk queries are GraphQL documents. This one requests sales/traffic
        // aggregated by date for a marketplace.
        var query = @"query MyQuery {
  analytics_salesAndTraffic_2024_04_24 {
    salesAndTrafficByDate(startDate: ""2024-01-01"" endDate: ""2024-01-07"" aggregateBy: DAY marketplaceIds: [""ATVPDKIKX0DER""]) {
      startDate
      sales { orderedProductSales { amount currencyCode } unitsOrdered }
    }
  }
}";

        var created = amazonConnection.DataKiosk.CreateQuery(new CreateQuerySpecification { Query = query });
        var queryId = created?.QueryId;
    }

    public void GetQueries()
    {
        var response = amazonConnection.DataKiosk.GetQueries(new ParameterGetQueries
        {
            ProcessingStatuses = new List<string> { "DONE", "IN_PROGRESS" },
            PageSize = 10,
            CreatedSince = DateTime.UtcNow.AddDays(-7),
        });

        var queries = response?.Queries;
        var nextToken = response?.Pagination?.NextToken; // page via ParameterGetQueries.PaginationToken
    }

    public void GetQueryAndDownloadResults()
    {
        var query = amazonConnection.DataKiosk.GetQuery("QUERY_ID");

        // When a query finishes successfully, DataDocumentId points at the results document.
        if (query?.ProcessingStatus == Query.ProcessingStatusEnum.DONE && !string.IsNullOrEmpty(query.DataDocumentId))
        {
            var document = amazonConnection.DataKiosk.GetDocument(query.DataDocumentId);
            var url = document?.DocumentUrl; // download the (gzip-compressed) JSONL results from here
        }
    }

    public void CancelQuery()
    {
        amazonConnection.DataKiosk.CancelQuery("QUERY_ID");
    }
}
