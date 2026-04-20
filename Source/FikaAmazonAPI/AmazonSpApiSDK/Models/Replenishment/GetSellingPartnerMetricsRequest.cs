using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Replenishment
{
    public class GetSellingPartnerMetricsRequest : IEquatable<GetSellingPartnerMetricsRequest>, IValidatableObject
    {
        [JsonConstructor]
        public GetSellingPartnerMetricsRequest() { }

        /// <summary>
        /// An optional time period used to group data in the response.
        /// </summary>
        /// <remarks>
        /// This is only valid for the PERFORMANCE time period type.
        /// </remarks>
        [DataMember(Name = "aggregationFrequency", EmitDefaultValue = false)]
        public AggregationFrequency? AggregationFrequency { get; set; }

        /// <summary>
        /// A time interval used to compute metrics.
        /// </summary>
        [DataMember(Name = "timeInterval", EmitDefaultValue = false)]
        public TimeInterval TimeInterval { get; set; }

        /// <summary>
        /// An optional list of metrics to request. If no metric value is provided, data for all metrics will be returned.
        /// </summary>
        [DataMember(Name = "metrics", EmitDefaultValue = false)]
        public Metric[] Metrics { get; set; }

        /// <summary>
        /// The time period type that determines whether the metrics requested are backward-looking (performance)
        /// or forward-looking (forecast).
        /// </summary>
        [DataMember(Name = "timePeriodType", EmitDefaultValue = false)]
        public TimePeriodType TimePeriodType { get; set; }

        /// <summary>
        /// Amazon marketplace identifier.
        /// </summary>
        [DataMember(Name = "marketplaceId", EmitDefaultValue = false)]
        public string MarketplaceId { get; set; }

        /// <summary>
        /// A list of replenishment program types for which to return metrics.
        /// </summary>
        [DataMember(Name = "programTypes", EmitDefaultValue = false)]
        public ProgramType[] ProgramTypes { get; set; }

        /// <inheritdoc />
        public bool Equals(GetSellingPartnerMetricsRequest other)
        {
            if (other == null)
                return false;

            return AggregationFrequency == other.AggregationFrequency &&
                   Equals(TimeInterval, other.TimeInterval) &&
                   Equals(Metrics, other.Metrics) &&
                   TimePeriodType == other.TimePeriodType &&
                   string.Equals(MarketplaceId, other.MarketplaceId, StringComparison.Ordinal);
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (obj is GetSellingPartnerMetricsRequest otherRequest)
                return Equals(otherRequest);

            return false;
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + (AggregationFrequency != null ? AggregationFrequency.GetHashCode() : 0);
            hash = hash * 23 + (TimeInterval != null ? TimeInterval.GetHashCode() : 0);
            hash = hash * 23 + (Metrics != null ? GetArrayHashCode(Metrics) : 0);
            hash = hash * 23 + TimePeriodType.GetHashCode();
            hash = hash * 23 + (MarketplaceId != null ? MarketplaceId.GetHashCode() : 0);
            return hash;
        }

        /// <summary>
        /// Calculates the hash code for an array.
        /// </summary>
        /// <param name="array">The array for which to calculate the hash code.</param>
        /// <returns>The hash code value calculated based on the elements of the array.</returns>
        private int GetArrayHashCode<T>(T[] array)
        {
            if (array == null) return 0;
            int hash = 17;
            foreach (var item in array)
            {
                hash = hash * 23 + (item != null ? item.GetHashCode() : 0);
            }

            return hash;
        }

        /// <inheritdoc />
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // Ensure MarketplaceId is not null or empty
            if (string.IsNullOrWhiteSpace(MarketplaceId))
            {
                yield return new ValidationResult(
                    "MarketplaceId is required.",
                    new[] { nameof(MarketplaceId) });
            }

            // Ensure TimeInterval is not null
            if (TimeInterval == null)
            {
                yield return new ValidationResult(
                    "TimeInterval is required.",
                    new[] { nameof(TimeInterval) });
            }

            // AggregationFrequency is only valid when TimePeriodType is PERFORMANCE
            if (TimePeriodType != TimePeriodType.PERFORMANCE && AggregationFrequency != null)
            {
                yield return new ValidationResult(
                    $"{nameof(AggregationFrequency)} is only valid when {nameof(TimePeriodType)} is " +
                    $"{nameof(TimePeriodType.PERFORMANCE)}.", new[] { nameof(AggregationFrequency) });
            }
        }
    }
}