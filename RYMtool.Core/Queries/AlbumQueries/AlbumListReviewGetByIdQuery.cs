using Microsoft.EntityFrameworkCore;
using RYMtool.Core.Interfaces;
using RYMtool.Core.Models;

namespace RYMtool.Core.Queries.AlbumQueries;

public class AlbumListReviewGetByIdQuery:Query<Album>,ISingleResultQuery
{
    private readonly int _id;

    public AlbumListReviewGetByIdQuery(int id)
    {
        _id = id;
    }

    protected override IQueryable<Album> GetQuery(DbSet<Album> dbSet)
    {
        return dbSet
            .Include(x => x.Ratings)
            .Include(x => x.Reviews)
            .Where(x => x.Id == _id);
    }
}