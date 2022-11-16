using Microsoft.EntityFrameworkCore;
using RYMtool.Core.Interfaces;
using RYMtool.Core.Models;

namespace RYMtool.Core.Queries.AlbumQueries;

public class AlbumGetAllOrderedQuery:Query<Album>,IListResultQuery
{
    
    private readonly Func<Album,string> _order;
    public AlbumGetAllOrderedQuery(string? order)
    {
        _order = order == "artist" ? album => album.Artist : album => album.Title;
    }

    protected override IQueryable<Album> GetQuery(DbSet<Album> dbSet)
    {
        return dbSet
            .Include(x => x.Ratings)
            .Include(x => x.Reviews)
            .OrderBy(_order)
            .AsQueryable(); 
    }
}
