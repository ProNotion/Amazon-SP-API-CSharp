using Newtonsoft.Json;

namespace FikaAmazonAPI.AmazonSpApiSDK.Runtime
{
    public class LWAAccessTokenRequestMeta
    {
        [JsonProperty(PropertyName = "grant_type")]
        public string GrantType { get; set; }

        [JsonProperty(PropertyName = "refresh_token")]
        public string RefreshToken { get; set; }

        [JsonProperty(PropertyName = "client_id")]
        public string ClientId { get; set; }

        [JsonProperty(PropertyName = "client_secret")]
        public string ClientSecret { get; set; }

        [JsonProperty(PropertyName = "scope")]
        public string Scope { get; set; }

        public override bool Equals(object obj)
        {
            LWAAccessTokenRequestMeta other = obj as LWAAccessTokenRequestMeta;

            return other != null &&
                GrantType == other.GrantType &&
                RefreshToken == other.RefreshToken &&
                ClientId == other.ClientId &&
                ClientSecret == other.ClientSecret &&
                Scope == other.Scope;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = (hash * 31) + (GrantType == null ? 0 : GrantType.GetHashCode());
                hash = (hash * 31) + (RefreshToken == null ? 0 : RefreshToken.GetHashCode());
                hash = (hash * 31) + (ClientId == null ? 0 : ClientId.GetHashCode());
                hash = (hash * 31) + (ClientSecret == null ? 0 : ClientSecret.GetHashCode());
                hash = (hash * 31) + (Scope == null ? 0 : Scope.GetHashCode());
                return hash;
            }
        }
    }
}
