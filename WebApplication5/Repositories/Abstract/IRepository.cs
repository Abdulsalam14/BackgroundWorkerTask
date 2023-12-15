using System.Linq.Expressions;

namespace WebApplication5.Repositories.Abstract
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
        T Get(Expression<Func<T, bool>> expression);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
