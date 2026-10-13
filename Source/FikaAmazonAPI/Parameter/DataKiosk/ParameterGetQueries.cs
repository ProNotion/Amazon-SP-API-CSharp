using FikaAmazonAPI.Search;
using System;
using System.Collections.Generic;

namespace FikaAmazonAPI.Parameter.DataKiosk
{
    /// <summary>
    /// Query parameters for the Data Kiosk getQueries operation.
    /// </summary>
    [CamelCase]
    public class ParameterGetQueries : ParameterBased
    {
        /// <summary>
        /// A list of processing statuses used to filter queries.
        /// Values: CANCELLED, DONE, FATAL, IN_PROGRESS, IN_QUEUE.
        /// </summary>
        public List<string> ProcessingStatuses { get; set; }

        /// <summary>
        /// The maximum number of queries to return in a single call. Between 1 and 100 (default 10).
        /// </summary>
        public int? PageSize { get; set; }

        /// <summary>
        /// The earliest query creation date and time (inclusive) to include in the response.
        /// </summary>
        public DateTime? CreatedSince { get; set; }

        /// <summary>
        /// The latest query creation date and time (inclusive) to include in the response.
        /// </summary>
        public DateTime? CreatedUntil { get; set; }

        /// <summary>
        /// A token to fetch a certain page of results when there are multiple pages.
        /// </summary>
        public string? PaginationToken { get; set; }
    }
}
