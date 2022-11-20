using RYMtool.Core.Dtos;
using RYMtool.Core.Exceptions;
using RYMtool.Core.Interfaces;
using RYMtool.Core.Models;
using RYMtool.Core.Queries.AlbumQueries;

namespace RYMtool.Core.Services;

public class AlbumService:IAlbumService
{
    private readonly IRepository<Album> _repository;

    public AlbumService(IRepository<Album> repository)
    {
        _repository = repository;
    }

    public async Task<List<Album>> GetAllAlbumsAsync(string order)
    {
        return await _repository.ListAsync(new AlbumGetAllOrderedQuery(order));
    }

    public async Task<Album> AddAsync(Album album)
    {
        return await _repository.AddAsync(album);
    }

    public async Task<List<Album>> GetTenRecommendedAlbumsAsync(string genre)
    {
        return await _repository.ListAsync(new AlbumGetTenRecommendedQuery(genre));
    }

    public async Task<Album> GetAlbumDetailAsync(int id)
    {
        var album = await _repository.GetByQueryAsync(new AlbumListReviewGetByIdQuery(id));
        if (album == null)
            throw new NotFoundException(nameof(Album),id);
        return album;
    }

    public async Task DeleteAlbumAsync(int id)
    {
        var album = await _repository.GetByIdAsync(id);
        if (album == null)
            throw new NotFoundException(nameof(album), id);
        await _repository.DeleteAsync(album);
    }
}