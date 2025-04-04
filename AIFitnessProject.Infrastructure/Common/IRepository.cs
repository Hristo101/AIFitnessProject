﻿namespace AIFitnessProject.Infrastructure.Common
{
    public interface IRepository
    {
        IQueryable<T> All<T>() where T : class;

        IQueryable<T> AllAsReadOnly<T>() where T : class;

        Task AddAsync<T>(T entity) where T : class;

        Task AddRangeAsync<T>(IEnumerable<T> entities) where T : class;


        Task<int> SaveChangesAsync();

        void Delete<T>(T entity) where T : class;

        Task<T?> GetByIdAsync<T>(int id) where T : class;

    }
}
