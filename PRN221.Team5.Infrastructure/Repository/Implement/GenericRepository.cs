﻿

using PRN221.Team5.Application.Common;

namespace Team5.Infrastructure.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity, new()
    {
        protected readonly DbContext dbContext;
        protected DbSet<T> dbSet;
        public GenericRepository(DbContext context)
        {
            dbContext = context;
            dbSet = context.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbSet.AsNoTracking().ToListAsync();
        }

        #region Create
        /// <summary>
        /// Add an entity to DbSet, need to call SaveChanges to save to database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<Guid> CreateAsync(T entity, bool isSaveChange = false)
        {
            await dbSet.AddAsync(entity);

            if (isSaveChange)
            {
                await SaveChangesAsync();
            }
            return entity.Id;
        }
        /// <summary>
        /// Add a list of entities to DbSet, need to call SaveChanges to save to database
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Guid>> CreateAsync(IEnumerable<T> entities, bool isSaveChange = false)
        {
            List<T> values = entities.ToList();

            await dbSet.AddRangeAsync(values);

            if (isSaveChange)
            {
                await SaveChangesAsync();
            }
            return values.Select(e => e.Id);
        }
        #endregion Create

        #region Delete
        /// <summary>
        /// Delete immediately by condition predicate without SaveChanges action 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<int> DeleteAsync(Expression<Func<T, bool>> predicate)
        {
            Expression<Func<T, bool>> isDeleted = p => p.IsDeleted == false;

            if (predicate == null)
            {
                predicate = isDeleted;
            }
            else
            {
                predicate = PredicateBuilder.And(isDeleted, predicate);
            }

            return await dbSet.Where(predicate)
                                .ExecuteDeleteAsync();
        }
        /// <summary>
        /// UpdateAsync IsDeleted to true by condition predicate without SaveChanges action
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> SoftDeleteAsync(Expression<Func<T, bool>> predicate)
        {
            Expression<Func<T, bool>> isDeleted = p => p.IsDeleted == false;

            if (predicate == null)
            {
                predicate = isDeleted;
            }
            else
            {
                predicate = PredicateBuilder.And(isDeleted, predicate);
            }

            return await dbSet.Where(predicate)
                                .ExecuteUpdateAsync(setter => setter.SetProperty(e => e.IsDeleted, true))
                                ;
        }
        #endregion Delete

        #region Update
        /// <summary>
        ///  Change stated of entity to Modified (mark this entity will update), need to call SaveChanges to save to database
        /// </summary>
        /// <param name="entity"></param>
        public async Task<int> UpdateAsync(T entity, bool isSaveChange = false)
        {
            dbContext.Attach(entity).State = EntityState.Modified;
            if (isSaveChange)
            {
                return await SaveChangesAsync();
            }
            return 0;
        }
        /// <summary>
        /// Update entity exist in database by condition predicate without SaveChanges action
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="setPropertyCalls"></param>
        /// <returns></returns>
        public async Task<int> UpdateAsync(Expression<Func<T, bool>>? predicate, Expression<Func<SetPropertyCalls<T>, SetPropertyCalls<T>>> setPropertyCalls)
        {
            Expression<Func<T, bool>> isDeleted = p => p.IsDeleted == false;

            if (predicate == null)
            {
                predicate = isDeleted;
            }
            else
            {
                predicate = PredicateBuilder.And(isDeleted, predicate);
            }

            var query = dbSet.AsQueryable();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return await query.ExecuteUpdateAsync(setPropertyCalls);
        }
        /// <summary>
        /// Update entity by id and other conditions with DTO object - Hàng lỗi nha đừng có đụng vào 
        /// </summary>
        /// <typeparam name="TDto"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="req"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<int> UpdateAsync<TDto>(Expression<Func<T, bool>> predicate, TDto req) where TDto : class, new()
        {
            var setPropertyCalls = req.GetSetPropertyCalls<T, TDto>();

            if (setPropertyCalls == null)
            {
                throw new ArgumentNullException("UpdateAsync - SetPropertyCalls is null");
            }

            return await UpdateAsync(predicate, setPropertyCalls);
        }
        #endregion Update

        #region Retrieve
        /// <summary>
        /// GetById first entity by predicate, this function is AsNoTracking
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<T?> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await dbSet.AsQueryable().AsNoTracking().FirstOrDefaultAsync(predicate);
        }

        /// <summary>
        /// Check entity exist in database by condition predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<bool> IsExist(Expression<Func<T, bool>> predicate)
        {
            var entity = await dbSet.AsQueryable().AsNoTracking()
                                    .Where(predicate)
                                    .Select(t => t.Id)
                                    .FirstOrDefaultAsync();

            return entity != null;
        }
        #endregion Retrieve

        /// <summary>
        /// Function save changes to database (Excute command to Db like: update, create, delete)
        /// </summary>
        /// <returns></returns>
        public async Task<int> SaveChangesAsync()
        {
            return await dbContext.SaveChangesAsync();
        }

        #region Retrieve Version 2.0
        /// <summary>
        /// GetAll entity by id and other conditions
        /// </summary>
        /// <param name="id"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<T?> GetById(Guid id, QueryHelper<T> queryHelper, bool isAsNoTracking = true)
        {
            if (queryHelper == null)
            {
                queryHelper = new QueryHelper<T>();
            }
            var query = dbSet.ApplyConditions(queryHelper, id, isAsNoTracking);

            return await query.SingleOrDefaultAsync();
        }
        /// <summary>
        /// GetAll entity by id and other conditions
        /// 
        /// This function will return mapping dto object map from entity
        /// </summary>
        /// <param name="id"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<TResult?> GetById<TResult>(Guid id, QueryHelper<T, TResult> queryHelper, bool isAsNoTracking = true) where TResult : class
        {
            if (queryHelper == null)
            {
                queryHelper = new QueryHelper<T, TResult>();
            }
            var query = dbSet.ApplyConditions(queryHelper, id, isAsNoTracking);

            return await query.SingleOrDefaultAsync();
        }
        /// <summary>
        /// GetById an entity is active and match condition predicate
        /// </summary>
        /// <param name="queryHelper"></param>
        /// <param name="isAsNoTracking"></param>
        /// <returns></returns>
        public async Task<T?> GetFirstOrDefault(QueryHelper<T> queryHelper, bool isAsNoTracking = true)
        {
            if (queryHelper == null)
            {
                queryHelper = new QueryHelper<T>();
            }

            var query = dbSet.ApplyConditions(queryHelper, isAsNoTracking: isAsNoTracking);

            return await query.FirstOrDefaultAsync();
        }
        /// <summary>
        /// GetById an entity has mapping dto object is active and match condition predicate
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="queryHelper"></param>
        /// <param name="isAsNoTracking"></param>
        /// <returns></returns>
        public async Task<TResult?> GetFirstOrDefault<TResult>(QueryHelper<T, TResult> queryHelper, bool isAsNoTracking = true) where TResult : class
        {
            if (queryHelper == null)
            {
                queryHelper = new QueryHelper<T, TResult>();
            }

            var query = dbSet.ApplyConditions(queryHelper, isAsNoTracking: isAsNoTracking);

            return await query.FirstOrDefaultAsync();
        }
        /// <summary>
        /// GetAll all entities are active and match condition predicate, this function is AsNoTracking
        /// </summary>
        /// <param name="queryHelper"></param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> Get(QueryHelper<T> queryHelper, bool isAsNoTracking = true)
        {
            if (queryHelper == null)
            {
                queryHelper = new QueryHelper<T>();
            }
            var query = dbSet.ApplyConditions(queryHelper, isAsNoTracking: isAsNoTracking);

            return await query.ToListAsync();
        }
        /// <summary>
        /// GetAll all entities are active and match condition predicate, this function is AsNoTracking
        /// 
        /// This function will return list of mapping dto object map from list of entity
        /// </summary>
        /// <param name="queryHelper"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TResult>> Get<TResult>(QueryHelper<T, TResult> queryHelper, bool isAsNoTracking = true) where TResult : class
        {
            if (queryHelper == null)
            {
                queryHelper = new QueryHelper<T, TResult>();
            }
            var query = dbSet.ApplyConditions(queryHelper, isAsNoTracking: isAsNoTracking);

            return await query.ToListAsync();
        }
        /// <summary>
        /// GetAll all entities are active and match condition predicate, this function is AsNoTracking
        /// </summary>
        /// <param name="queryHelper"></param>
        /// <returns>
        ///  PagedList is a class derived from List<TSource> and it is used to represent pagination of a list of objects.
        /// </returns>
        public async Task<PagedList<T>> GetWithPagination(QueryHelper<T> queryHelper, bool isAsNoTracking = true)
        {
            if (queryHelper == null)
            {
                queryHelper = new QueryHelper<T>();
            }
            var pagedList = new PagedList<T>();

            var query = dbSet.ApplyConditions(queryHelper, isAsNoTracking: isAsNoTracking);

            await pagedList.LoadData(query, queryHelper.PagingParams);

            return pagedList;
        }
        /// <summary>
        /// GetAll all entities are active and match condition predicate, this function is AsNoTracking
        /// 
        /// This function will return PagedList of mapping dto object map from list of entity
        /// </summary>
        /// <param name="queryHelper"></param>
        /// <returns>
        ///  PagedList is a class derived from List<TSource> and it is used to represent pagination of a list of objects.
        /// </returns>
        public async Task<PagedList<TResult>> GetWithPagination<TResult>(QueryHelper<T, TResult> queryHelper, bool isAsNoTracking = true) where TResult : class
        {
            if (queryHelper == null)
            {
                queryHelper = new();
            }

            var pagedList = new PagedList<TResult>();
            if (queryHelper == null)
            {
                queryHelper = new QueryHelper<T, TResult>();
            }

            var query = dbSet.ApplyConditions(queryHelper, isAsNoTracking: isAsNoTracking);

            await pagedList.LoadData(query, queryHelper.PagingParams);
            return pagedList;
        }
        #endregion Retrieve Version 2.0

        #region Dispose
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                }
                dbSet = null;
            }
            disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~GenericRepository()
        {
            Dispose(false);
        }
        #endregion Dispose
    }
}
