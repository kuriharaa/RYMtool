using Microsoft.EntityFrameworkCore;
using RYMtool.Core.Interfaces;
using RYMtool.Core.Models;

namespace RYMtool.Core.Queries.AlbumQueries;

public class AlbumGetTenRecommendedQuery:Query<Album>,IListResultQuery
{
    private readonly string _genre;

    public AlbumGetTenRecommendedQuery(string genre)
    {
        _genre = genre;
    }

    protected override IQueryable<Album> GetQuery(DbSet<Album> dbSet)
    {
        return dbSet
            .Include(x => x.Ratings)
            .Include(x => x.Reviews)
            .Where(x => x.Reviews.Count>=1)
            .Where(x => string.IsNullOrEmpty(_genre)==true || x.Genre.ToLower()==_genre.ToLower())
            .OrderByDescending(x => x.Ratings!.Sum(r => r.Score))
            .Take(10);

    }
}