using PRN221.Team5.Application.Service.Interface;
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

        private IGenericRepository<Animal> _animal;
        public IGenericRepository<Animal> Animal
        {
            get
            {
                if (_animal == null)
                {
                    _animal = new GenericRepository<Animal>(_dbContext);
                }
                return _animal;
            }
        }

        private IGenericRepository<ZooSection> _zooSection;
        public IGenericRepository<ZooSection> ZooSection
        {
            get
            {
                if (_zooSection == null)
                {
                    _zooSection = new GenericRepository<ZooSection>(_dbContext);
                }
                return _zooSection;
            }
        }

        private IGenericRepository<Cage> _cage;
        public IGenericRepository<Cage> Cage
        {
            get
            {
                if (_cage == null)
                {
                    _cage = new GenericRepository<Cage>(_dbContext);
                }
                return _cage;
            }
        }

        private IGenericRepository<TraineerProfile> _trainerProfile;
        public IGenericRepository<TraineerProfile> TrainerProfile
        {
            get
            {
                if (_trainerProfile == null)
                {
                    _trainerProfile = new GenericRepository<TraineerProfile>(_dbContext);
                }
                return _trainerProfile;
            }
        }
        private IGenericRepository<AnimalSpecie> _AnimalSpecie;
        public IGenericRepository<AnimalSpecie> AnimalSpecie
        {
            get
            {
                if (_AnimalSpecie == null)
                {
                    _AnimalSpecie = new GenericRepository<AnimalSpecie>(_dbContext);
                }
                return _AnimalSpecie;
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
