using System;
using Newtonsoft.Json;

namespace PrismChuckNorris.Models
{
    public class Joke
    {
        [JsonProperty("category")]
        public object Category { get; set; }

        [JsonProperty("icon_url")]
        public string IconUrl { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
