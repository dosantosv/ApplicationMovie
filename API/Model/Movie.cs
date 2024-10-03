using Newtonsoft.Json;

namespace API.Model
{
    public class Movie
    {

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "query")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "overview")]
        public string Overview { get; set; }

        [JsonProperty(PropertyName = "poster_path")]
        public string Poster { get; set; }

        [JsonProperty(PropertyName = "cast")]
        public List<Actor> Cast { get; set; }

        [JsonProperty(PropertyName = "results")]
        public List<Video> Videos { get; set; }

    }
}
