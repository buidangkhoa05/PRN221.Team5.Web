﻿
using PRN221.Team5.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team5.Application.Repository
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangeAsync(CancellationToken cancellationToken = default);
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RolebackTransactionAsync();

        #region Repository
        IGenericRepository<Account> Account { get; }
        IGenericRepository<ZooNews> ZooNews { get; }
        IGenericRepository<Animal> Animal { get; }
        IGenericRepository<ZooSection> ZooSection { get; }
        IGenericRepository<Cage> Cage { get; }
        IGenericRepository<AnimalSpecie> AnimalSpecie { get; }
        IGenericRepository<TraineerProfile> TrainerProfile { get; }
        IGenericRepository<Food> Food { get; }
        IGenericRepository<Meal_Food> Meal_Food { get; }
        IGenericRepository<Meal_Animal> Meal_Animal { get; }
        IGenericRepository<Meal> Meal { get; }
        IGenericRepository<AnimalTraining> AnimalTraining { get; }
        public IGenericRepository<Cage_Animal> CageAnimal { get; }
        #endregion Repository
    }
}
