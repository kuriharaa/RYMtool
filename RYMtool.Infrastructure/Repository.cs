using Microsoft.EntityFrameworkCore;
using RYMtool.Core.Interfaces;
using RYMtool.Core.Models;
using RYMtool.Core.Queries;
using RYMtool.Infrastructure.Extensions;

namespace RYMtool.Infrastructure;

public class Repository<T>:IRepository<T> where T: class, IAggregateRoot
{
    private readonly DataContext _context;

    public Repository(DataContext context)
    {
        _context = context;
    }

    public async Task<T> AddAsync(T entity)
    {
        if (await Exists(entity))
            await UpdateAsync(entity);
        else
        {
            await _context.Set<T>().AddAsync(entity);
            await SaveChangesAsync();
        }
        return entity;
    } 
    public async Task AddRangeAsync(List<T> entity)
    {
        await _context.Set<T>().AddRangeAsync(entity);
        await SaveChangesAsync();
    }

    public async Task<T?> GetByIdAsync<TId>(TId id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task<T?> GetByQueryAsync<TQuery>(TQuery query) where TQuery : Query<T>, ISingleResultQuery
    {
        return await query.Execute(_context.Set<T>()).FirstOrDefaultAsync();
    }

    public async Task<List<T>> ListAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }
    
    public async Task<List<T>> ListAsync<TQuery>(TQuery query) where TQuery:Query<T>,IListResultQuery
    {
        return await query.Execute(_context.Set<T>()).ToListAsyncSafe();
    }

    public async Task UpdateAsync(T entity)
    {
        _context.Set<T>().Update(entity);
        await SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _context.Set<T>().Remove(entity);
        await SaveChangesAsync();
    }

    private async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    private async Task<bool> Exists(T entity)
    {
        return await _context.Set<T>().AnyAsync(e => e == entity);
    }
}