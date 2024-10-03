using API.APIResponse;
using API.Model;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;
using System.Net;

namespace API.APIClient
{
    public class ThemoviedbAPIClient
    {
        private readonly RestClient _restClient;

        public ThemoviedbAPIClient()
        {
            Dictionary<string, string> defaultHeaders = new()
            {
                { "Content-Type", "application/json" },
                { "Accept", "application/json" },
                { "Authorization", "Bearer eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiI4MGJhOTc5YzkwZDkzZGY5NDJkMTU1Y2Y1NWM0Njg2NiIsIm5iZiI6MTcyNzQ1OTU2Mi4yOTQwODgsInN1YiI6IjY2ZjZmMDBjZTBiZjdhYzI4NTk2OGY4NyIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.lzI2dXcpta9epyJ91GXcXo-31H2HiOU8jFR_VTtqOUg"}
            };

            var options = new RestClientOptions("https://api.themoviedb.org/3/");

            _restClient = new(
                options,
                configureSerialization: s => s.UseNewtonsoftJson()         
            );

            _restClient.AddDefaultHeaders(defaultHeaders);
        }

        public (int TotalPages, List<Movie> Movies) GetMovies(string movieName, int page)
        {

            var request = new RestRequest("search/movie", Method.Get);
            request.AddParameter("query", movieName);
            request.AddParameter("page", page);
            request.AddParameter("language", "pt-BR");

            var response = _restClient.Execute(request);

            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                var movieResponse = JsonConvert.DeserializeObject<MovieResponse>(response.Content);
                return new(movieResponse.TotalPages, movieResponse.Results);
            }

            return default;

        }

        public List<Actor> GetActors(int movieId)
        {
            var request = new RestRequest($"movie/{movieId}/credits", Method.Get);

            var response = _restClient.Execute(request);

            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                var actorReponse = JsonConvert.DeserializeObject<ActorResponse>(response.Content);
                return actorReponse.Cast;
            }

            return [];
        }

        public List<Video> GetVideos(int movieId)
        {
            var request = new RestRequest($"movie/{movieId}/videos");

            var response = _restClient.Execute(request);

            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                var videoResponse = JsonConvert.DeserializeObject<VideoResponse>(response.Content);
                return videoResponse.Videos;
            }

            return [];
        }
    }
}
