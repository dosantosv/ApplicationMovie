using API.Model;
using Newtonsoft.Json;

namespace API.APIResponse
{
    class ActorResponse
    {

        [JsonProperty(PropertyName = "id")]
        public int MovieId { get; set; }

        [JsonProperty(PropertyName = "cast")]
        public List<Actor> Cast { get; set; }


    }
}
