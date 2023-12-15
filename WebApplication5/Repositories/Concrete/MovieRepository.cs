using System.Linq.Expressions;
using WebApplication5.Data;
using WebApplication5.Entities;
using WebApplication5.Repositories.Abstract;

namespace WebApplication5.Repositories.Concrete
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieDBContext _dbcontext;

        public MovieRepository(MovieDBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public void Add(Movie entity)
        {
            _dbcontext.Movies.Add(entity);
            _dbcontext.SaveChanges();
        }

        public void Delete(Movie entity)
        {
            _dbcontext.Remove(entity);
            _dbcontext.SaveChanges();
        }

        public Movie Get(Expression<Func<Movie, bool>> expression)
        {
            var movie= _dbcontext.Movies.FirstOrDefault(expression);
            return movie;
        }

        public List<Movie> GetAll()
        {
            return _dbcontext.Movies.ToList();
        }

        public void Update(Movie entity)
        {
            _dbcontext.Update(entity);
        }
    }
}
