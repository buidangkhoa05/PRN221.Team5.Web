using PRN221.Team5.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Team5.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _dbContext;
        private IDbContextTransaction _transaction;


        public UnitOfWork()
        {
            if (_dbContext == null)
            {
                _dbContext = new ApplicationDbContext();
            }
        }

        #region Repository 
        private IGenericRepository<Account> _account;
        public IGenericRepository<Account> Account
        {
            get
            {
                if (_account == null)
                {
                    _account = new GenericRepository<Account>(_dbContext);
                }
                return _account;
            }
        }

        private IGenericRepository<ZooNews> _zooNews;
        public IGenericRepository<ZooNews> ZooNews
        {
            get
            {
                if (_zooNews == null)
                {
                    _zooNews = new GenericRepository<ZooNews>(_dbContext);
                }
                return _zooNews;
            }
        }
        #endregion Repository


        public async Task BeginTransactionAsync()
        {
            if (_transaction == null)
            {
                _transaction = await _dbContext.Database.BeginTransactionAsync();
            }
        }

        public async Task CommitTransactionAsync()
        {
            if (_transaction is null)
                return;

            try
            {
                await _dbContext.SaveChangesAsync();
                await _transaction.CommitAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
            catch
            {
                await RolebackTransactionAsync();
            }
        }

        public async Task RolebackTransactionAsync()
        {
            if (_transaction is null)
                return;

            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();
            _transaction = null;
        }

        public async Task<int> SaveChangeAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
