using API.Model;
using Newtonsoft.Json;

namespace API.APIResponse
{
    public class MovieResponse
    {

        [JsonProperty(PropertyName = "results")]
        public List<Movie> Results { get; set; }

        [JsonProperty(PropertyName = "total_pages")]
        public int TotalPages { get; set; }
    }
}
