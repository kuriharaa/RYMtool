using RYMtool.Core.Models;

namespace RYMtool.Core.Services;

public interface IAlbumService:IService
{
    Task<List<Album>> GetAllAlbumsAsync(string? order);
    Task<Album> AddAsync(Album album);
    Task<List<Album>> GetTenRecommendedAlbumsAsync(string? genre);
    Task<Album> GetAlbumDetailAsync(int id);
    Task DeleteAlbumAsync(int id);
}