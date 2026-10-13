using Microsoft.Extensions.Configuration;

namespace FikaAmazonAPI.SampleCode
{
    /// <summary>
    /// Helpers for reading the credentials the samples need.
    ///
    /// <see cref="AmazonCredential"/> requires ClientId, ClientSecret and RefreshToken —
    /// <c>AmazonConnection.ValidateCredentials</c> throws when any of them is missing.
    /// Reading them through these helpers fails at the point of the missing setting and
    /// names the key, instead of letting a null travel into the SDK.
    /// </summary>
    public static class SampleConfiguration
    {
        /// <summary>Reads a required setting from configuration (appsettings.json / user secrets).</summary>
        public static string Required(this IConfiguration config, string key) =>
            config.GetSection(key).Value
                ?? throw new InvalidOperationException(
                    $"Missing configuration value '{key}'. Add it to appsettings.json or user secrets.");

        /// <summary>Reads a required environment variable.</summary>
        public static string RequiredEnv(string name) =>
            Environment.GetEnvironmentVariable(name)
                ?? throw new InvalidOperationException(
                    $"Missing environment variable '{name}'.");
    }
}
