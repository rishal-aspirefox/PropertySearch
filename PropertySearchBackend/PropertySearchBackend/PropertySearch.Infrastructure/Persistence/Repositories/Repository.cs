using Microsoft.EntityFrameworkCore;
using PropertySearch.Core.Interfaces;
using System.Linq.Expressions;

namespace PropertySearch.Infrastructure.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public IQueryable<T> GetAll() => _dbSet.AsQueryable();

        public IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet.AsQueryable();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return query;
        }

        public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);

        public async Task<T?> FindAsync(params object[] keyValues) =>
            await _dbSet.FindAsync(keyValues);

        public async Task SaveAsync() => await _context.SaveChangesAsync();
    }
}
