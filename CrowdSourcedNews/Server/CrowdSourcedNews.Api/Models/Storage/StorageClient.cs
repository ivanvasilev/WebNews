using Newtonsoft.Json;

namespace CrowdSourcedNews.Api.Models.Storage
{
    public class StorageClient
    {
        [JsonProperty("client_id")]
        public string ClientId { get; set; }
        [JsonProperty("client_secret")]
        public string ClientSecret { get; set; }
    }
}
