using System.Linq.Expressions;
using WebApplication5.Entities;
using WebApplication5.Repositories.Abstract;
using WebApplication5.Services.Abstract;

namespace WebApplication5.Services.Concrete
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _repository;

        public MovieService(IMovieRepository repository)
        {
            _repository = repository;
        }

        public void Add(Movie entity)
        {
           _repository.Add(entity);
        }


        public Movie Get(Expression<Func<Movie, bool>> expression)
        {
            return _repository.Get(expression);
        }

        public List<Movie> GetAll()
        {
            return _repository.GetAll();
        }

    }
}
