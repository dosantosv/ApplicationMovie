using API.Model;
using Newtonsoft.Json;

namespace API.APIResponse
{
    public class VideoResponse
    {

        [JsonProperty(PropertyName = "id")]
        public int MovieId { get; set; }

        [JsonProperty(PropertyName = "results")]
        public List<Video> Videos { get; set; }

    }
}
