using Microsoft.EntityFrameworkCore;
using RYMtool.Core.Interfaces;
using RYMtool.Core.Models;

namespace RYMtool.Core.Queries;

public class ReviewsGetByAlbumIdQuery:Query<Review>,IListResultQuery
{
    private readonly int _id;

    public ReviewsGetByAlbumIdQuery(int id)
    {
        _id = id;
    }

    protected override IQueryable<Review> GetQuery(DbSet<Review> dbSet)
    {
        return dbSet.Where(x => x.AlbumId == _id);
    }
}