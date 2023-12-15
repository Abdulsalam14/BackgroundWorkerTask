using WebApplication5.Entities;

namespace WebApplication5.Services.Abstract
{
    public interface IOmdbService
    {
        Task<Movie> GetFilmAsync();
    }
}
