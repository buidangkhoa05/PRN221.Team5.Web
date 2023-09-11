using System.Linq.Expressions;

namespace PRN221.Team5.Application.Repository.Interface
{
    public interface IGenericRepository<T>
    {
        Task<int> SaveChangesAsync();
        Task CreateAsync(T entity);
        Task DeleteAsync(Func<T, bool> predicate);
        Task SoftDeleteAsync(Func<T, bool> predicate);
        void Update(T entity);
        Task<T> GetById(Guid id, Expression<Func<T, bool>>? predicate = null, params Expression<Func<T, object>>[]? includes);
        Task<IEnumerable<T>> GetWithCondition(Expression<Func<T, bool>>? predicate = null, params Expression<Func<T, object>>[]? includes);
        Task<PagedList<T>> GetWithPaging(IQueryable<T> dataQuery, QueryParameters pagingParams);
        Task<PagedList<T>> GetWithPaging(IQueryable<T> dataQuery, QueryParameters pagingParams, Expression<Func<T, bool>> predicate);
    }
}
