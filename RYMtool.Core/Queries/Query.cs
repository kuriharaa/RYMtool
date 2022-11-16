using Microsoft.EntityFrameworkCore;
using RYMtool.Core.Models;

namespace RYMtool.Core.Queries;

public abstract class Query<T> where T : class,IAggregateRoot
{
    public IQueryable<T> Execute(DbSet<T> dbSet)
    {
        return GetQuery(dbSet);
    }

    protected abstract IQueryable<T> GetQuery(DbSet<T> dbSet);
}