﻿using NZWalksCleanArch.Entities.Models;

namespace NZWalksCleanArch.DataService.Repositories.Interfaces;

public interface IGenericRepository<T> where T : class
{
    Task<IEnumerable<T>?> GetAllAsync(Filter filter);
    Task<T?> GetByIdAsync(Guid id);
    Task<bool> CreateAsync(T entity);
    Task<bool> UpdateAsync(Guid id, T entity);
    Task<bool> DeleteAsync(Guid id, bool shadowDelete = true);
}
