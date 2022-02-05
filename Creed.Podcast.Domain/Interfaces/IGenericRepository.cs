using System.Linq.Expressions;
namespace Creed.Podcast.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetById(object id);
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> Get<TOrderKey>(
            Expression<Func<T, bool>> filter,
            Expression<Func<T, object>> include,
            Expression<Func<T, TOrderKey>> orderBy);
        Task Add(T entity);
        Task AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        void Remove(object id);
        void RemoveRange(IEnumerable<T> entities);
    }
}