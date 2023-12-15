using Newtonsoft.Json.Linq;
using System.Linq.Expressions;
using System.Text.Json;
using WebApplication5.Entities;
using WebApplication5.Services.Abstract;

namespace WebApplication5.Services.Concrete
{
    public class OMDBService:IOmdbService
    {
        private readonly HttpClient _httpClient;

        private readonly IMovieService _movieService;

        public OMDBService(HttpClient httpClient,IMovieService movieService)
        {
            _httpClient = httpClient;
            _movieService = movieService;
        }

        public async Task<Movie> GetFilmAsync()
        {
            var random = new Random();
            var apiKey = "286b2a27";

            do
            {
                var randomChar = (char)random.Next('a', 'z' + 1);

                var url = $"http://www.omdbapi.com/?apikey={apiKey}&s=the_{randomChar}&type=movie";
                var response = await _httpClient.GetAsync(url);

                var jsonResult = await response.Content.ReadAsStringAsync();

                OmdbResponse omdbResponse = JsonSerializer.Deserialize<OmdbResponse>(jsonResult);

                if (!(omdbResponse?.Search?.Any() ?? false))continue;

                foreach (var movieData in omdbResponse.Search)
                {
                    var existingMovie = _movieService.Get(m => m.imdbID == movieData.imdbID);

                    if (existingMovie is null)
                    {
                        Movie movie = new Movie()
                        {
                            imdbID = movieData.imdbID,
                            Type = movieData.Type,
                            Title = movieData.Title,
                            Year = movieData.Year,
                            Poster = movieData.Poster
                        };

                        return movie;
                    }
                }
            } while (true);
        }

    }
}
