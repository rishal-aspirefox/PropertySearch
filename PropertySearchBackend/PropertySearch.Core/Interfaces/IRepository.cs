using System.Linq.Expressions;

namespace PropertySearch.Core.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includes);

        Task AddAsync(T entity);
        Task<T?> FindAsync(params object[] keyValues);
        Task SaveAsync();
    }
}
