using RYMtool.Core.Dtos;
using RYMtool.Core.Dtos.Responses;
using RYMtool.Core.Models;
using System.Net;

namespace RYMtool.Core.Services;

public interface IAlbumService:IService
{
    Task<ResponseAlbums> GetAllAlbumsAsync(string order);
    Task<Album> AddAsync(AlbumCreateDto album);
    Task<ResponseAlbums> GetTenRecommendedAlbumsAsync(string genre);
    Task<ResponseAlbum> GetAlbumDetailAsync(int id);
    Task<HttpStatusCode> DeleteAlbumAsync(int id);
}