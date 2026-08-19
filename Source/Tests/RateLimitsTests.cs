using FikaAmazonAPI.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    public class RateLimitsTests
    {
        [Test]
        [TestCase(0.1, 1, 3, 20000)]
        [TestCase(0.5, 1, 3, 4000)]
        [TestCase(1, 5, 10, 5000)]
        public async Task NextRate_WaitsExpectedLengthOfTime(decimal rate, int burst, int numberRequests, int expectedWaitMilliseconds)
        {
            // Arrange
            var rateLimit = new RateLimits(rate, burst);

            var stopwatch = new Stopwatch();

            // Act
            stopwatch.Start();
            for (int i = 0; i < numberRequests; i++)
            {
                await rateLimit.NextRate(RateLimitType.UNSET);
            }
            stopwatch.Stop();

            // Assert
            Assert.That(stopwatch.ElapsedMilliseconds, Is.GreaterThanOrEqualTo(expectedWaitMilliseconds));
            // allow a second for additional time taken by the test to run
            Assert.That(stopwatch.ElapsedMilliseconds, Is.LessThanOrEqualTo(expectedWaitMilliseconds + 1000));
        }

        // Regression test for issue #940: when many requests for the same rate limit type run in parallel
        // against the shared RateLimits instance, the token bucket must drain within the expected window.
        // Before NextRate was serialized, racing threads each pushed LastRequest further into the future,
        // so the limiter never recovered and effectively hung until the process was restarted.
        [Test]
        public async Task ConcurrentRequests_DrainWithinExpectedWindow()
        {
            // rate 1/s, burst 5 => 10 concurrent requests = 5 immediate + 5 spaced ~1s apart ~= 5s.
            var rateLimit = new RateLimits(1.0M, 5);

            var stopwatch = Stopwatch.StartNew();

            var tasks = Enumerable.Range(0, 10)
                .Select(_ => rateLimit.NextRate(RateLimitType.UNSET))
                .ToArray();
            await Task.WhenAll(tasks);

            stopwatch.Stop();

            Assert.That(stopwatch.ElapsedMilliseconds, Is.GreaterThanOrEqualTo(4000));
            Assert.That(stopwatch.ElapsedMilliseconds, Is.LessThanOrEqualTo(8000));
        }
    }
}
