using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace FikaAmazonAPI.AmazonSpApiSDK.Models.Replenishment
{
    public class TimeInterval : IEquatable<TimeInterval>, IValidatableObject
    {
        /// <summary>
        /// When this object is used as a request parameter, the specified startDate is adjusted based
        /// on the aggregation frequency.
        /// </summary>
        [DataMember(Name = "startDate", EmitDefaultValue = false)]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// When this object is used as a request parameter, the specified endDate is adjusted based
        /// on the aggregation frequency.
        /// </summary>
        /// <remarks>
        /// The end date may be adjusted to a lower value based on the data available.
        /// </remarks>
        [DataMember(Name = "endDate", EmitDefaultValue = false)]
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Returns true if the specified <see cref="TimeInterval"/> has the same start and end dates as this instance.
        /// </summary>
        /// <param name="other">The <see cref="TimeInterval"/> to compare with this instance.</param>
        public bool Equals(TimeInterval other)
        {
            if (other == null)
                return false;

            return StartDate == other.StartDate && EndDate == other.EndDate;
        }

        /// <summary>
        /// Returns true if the specified object is a <see cref="TimeInterval"/> equal to this instance.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        public override bool Equals(object obj)
        {
            if (obj is TimeInterval other)
                return Equals(other);
            return false;
        }

        /// <summary>
        /// Returns a hash code for this instance based on <see cref="StartDate"/> and <see cref="EndDate"/>.
        /// </summary>
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + StartDate.GetHashCode();
                hash = hash * 23 + EndDate.GetHashCode();
                return hash;
            }
        }

        /// <summary>
        /// Validates that <see cref="StartDate"/> and <see cref="EndDate"/> are set and that the start date precedes the end date.
        /// </summary>
        /// <param name="validationContext">The validation context.</param>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (StartDate == default)
            {
                yield return new ValidationResult(
                    "StartDate is required.",
                    new[] { nameof(StartDate) });
            }

            if (EndDate == default)
            {
                yield return new ValidationResult(
                    "EndDate is required.",
                    new[] { nameof(EndDate) });
            }

            if (StartDate != default && EndDate != default && StartDate > EndDate)
            {
                yield return new ValidationResult(
                    "StartDate must be before EndDate.",
                    new[] { nameof(StartDate) });
            }
        }
    }
}
