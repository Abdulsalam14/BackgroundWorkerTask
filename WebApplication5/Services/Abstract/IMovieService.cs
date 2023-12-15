using System.Linq.Expressions;
using WebApplication5.Entities;

namespace WebApplication5.Services.Abstract
{
    public interface IMovieService
    {
        List<Movie> GetAll();
        Movie Get(Expression<Func<Movie, bool>> expression);
        void Add(Movie entity);
    }
}
