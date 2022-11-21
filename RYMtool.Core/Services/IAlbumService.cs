using RYMtool.Core.Dtos;
using RYMtool.Core.Models;
using System.Net;

namespace RYMtool.Core.Services;

public interface IAlbumService:IService
{
    Task<List<AlbumDto>> GetAllAlbumsAsync(string? order);
    Task<Album> AddAsync(AlbumCreateDto album);
    Task<List<AlbumDto>> GetTenRecommendedAlbumsAsync(string? genre);
    Task<AlbumListReviewDto?> GetAlbumDetailAsync(int id);
    Task<HttpStatusCode> DeleteAlbumAsync(int id);
}