using Newtonsoft.Json;

namespace API.Model
{
    public class Actor
    {

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "character")]
        public string Character { get; set; }

    }
}
