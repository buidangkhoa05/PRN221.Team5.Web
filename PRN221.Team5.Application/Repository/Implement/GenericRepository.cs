﻿
using LinqKit;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace PRN221.Team5.Application.Repository.Implement
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly DbContext _context;
        protected readonly DbSet<T> dbSet;
        public GenericRepository(DbContext context)
        {
            _context = context;
            dbSet = context.Set<T>();
        }

        #region Create
        public async Task CreateAsync(T entity)
        {
            await dbSet.AddAsync(entity);
        }
        #endregion

        #region Delete
        /// <summary>
        /// Delete immediately by condition predicate without SaveChanges action 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task DeleteAsync(Func<T, bool> predicate)
        {
            var result = await dbSet.Where(predicate).AsQueryable().ExecuteDeleteAsync();

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task SoftDeleteAsync(Func<T, bool> predicate)
        {
            //T _entity = await GetByIdAsync(id);
            //if (_entity != null)
            //{
            //    _entity.is_deleted = true;
            //    await UpdateAsync(_entity);
            //}

            var result = await dbSet.Where(predicate)
                                    .AsQueryable()
                                    .ExecuteUpdateAsync(setter => setter.SetProperty(e => e.IsDeleted, false));
        }
        #endregion Delete

        #region Update
        public async Task UpdateAsync(T entity)
        {
            _context.Attach(entity).State = EntityState.Modified;
        }
        #endregion Update

        #region Retrieve
        public async Task<T> GetById(Guid id, Expression<Func<T, bool>>? predicate = null, params Expression<Func<T, object>>[]? includes)
        {
            Expression<Func<T, bool>> isNotDeleteCondition = p => p.IsDeleted == false && p.Id == id;

            if (predicate == null)
            {
                predicate = isNotDeleteCondition;
            }
            else
            {
                predicate = PredicateBuilder.And(isNotDeleteCondition, predicate);
            }

            if (includes == null)
            {
                return await dbSet.AsNoTracking().Where(predicate).SingleOrDefaultAsync();
            }
            else
            {
                var query = dbSet.AsNoTracking().Where(predicate);
                return await query.Includes(includes).SingleOrDefaultAsync();
            }
        }

        public async Task<IEnumerable<T>> GetWithCondition(Expression<Func<T, bool>>? predicate = null, params Expression<Func<T, object>>[]? includes)
        {
            Expression<Func<T, bool>> isNotDeleteCondition = p => p.IsDeleted == false;

            if (predicate == null)
            {
                predicate = isNotDeleteCondition;
            }
            else
            {
                predicate = PredicateBuilder.And(isNotDeleteCondition, predicate);
            }

            if (includes == null)
            {
                return await dbSet.AsNoTracking().Where(predicate).ToListAsync();
            }
            else
            {
                var query = dbSet.AsNoTracking().Where(predicate);

                return query.Includes(includes);
            }
        }

        public async Task<PagedList<T>> GetWithPaging(IQueryable<T> dataQuery, QueryParameters pagingParams)
        {
            PagedList<T> pagedRequests = new PagedList<T>();
            if (pagingParams.PageSize <= 0 || pagingParams.PageNumber <= 0)
            {
                throw new ArgumentException("Page number or page size must be greater than 0");
            }
            else
            {
                await pagedRequests.LoadData(dataQuery.Where(c => c.IsDeleted == false).OrderByDescending(c => c.CreatedAt), pagingParams.PageNumber, pagingParams.PageSize);
            }

            return pagedRequests;

        }

        public async Task<PagedList<T>> GetWithPaging(IQueryable<T> dataQuery, QueryParameters pagingParams, Expression<Func<T, bool>> predicate)
        {
            PagedList<T> pagedRequests = new PagedList<T>();

            if (pagingParams.PageSize <= 0 || pagingParams.PageNumber <= 0)
            {
                throw new ArgumentException("Page number or page size must be greater than 0");
            }
            else
            {
                await pagedRequests.LoadData(dataQuery.Where(c => c.IsDeleted == false).OrderByDescending(c => c.CreatedAt), pagingParams.PageNumber, pagingParams.PageSize, predicate);
            }
            return pagedRequests;
        }
        #endregion Retrieve

        //public async Task<IList<T>> WhereAsync(Expression<Func<T, bool>> predicate, params string[] navigationProperties)
        //{
        //    List<T> list;
        //    var query = dbSet.AsQueryable();
        //    foreach (var property in navigationProperties)
        //    {
        //        query = query.Include(property);
        //    }
        //    list = await query.Where(predicate).AsNoTracking().ToListAsync();
        //    return list;
    }
}