using Newtonsoft.Json;

namespace API.Model
{
    public class Video
    {

        [JsonProperty(PropertyName = "key")]
        public string Key { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

    }
}
