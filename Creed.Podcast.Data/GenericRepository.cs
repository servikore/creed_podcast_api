using Creed.Podcast.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Creed.Podcast.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly PodcastDbContext _context;
        internal DbSet<T> dbSet;
        public GenericRepository(PodcastDbContext context)
        {
            _context = context;
            dbSet = _context.Set<T>();
        }

        public async Task Add(T entity)
        {
            await dbSet.AddAsync(entity);
        }

        public async Task AddRange(IEnumerable<T> entities)
        {
            await dbSet.AddRangeAsync(entities);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<T> GetById(object id)
        {
            return await dbSet.FindAsync(id);
        }
        public async Task<IEnumerable<T>> Get<TOrderKey>(
            Expression<Func<T, bool>> filter,
            Expression<Func<T, object>> include,            
            Expression<Func<T, TOrderKey>> orderBy)
        {
           return await dbSet.Where(filter)
                .Include(include)
                .OrderBy(orderBy)
                .ToListAsync();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void Remove(object id)
        {
            T entityToDelete = dbSet.Find(id);
            Remove(entityToDelete);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }
    }
}