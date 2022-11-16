using RYMtool.Core.Models;
using RYMtool.Core.Queries;

namespace RYMtool.Core.Interfaces;

public interface IRepository<T> where T: class, IAggregateRoot
{
    Task<T> AddAsync(T entity);
    Task AddRangeAsync(List<T> entity);
    Task<T?> GetByIdAsync<TId>(TId id);
    Task<T?> GetByQueryAsync<TQuery>(TQuery query )where TQuery:Query<T>,ISingleResultQuery;
    Task<List<T>> ListAsync();
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task<List<T>> ListAsync<TQuery>(TQuery query )where TQuery:Query<T>,IListResultQuery;
}