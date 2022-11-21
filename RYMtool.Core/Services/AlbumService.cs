using RYMtool.Core.Dtos;
using RYMtool.Core.Exceptions;
using RYMtool.Core.Interfaces;
using RYMtool.Core.Models;
using RYMtool.Core.Queries.AlbumQueries;
using AutoMapper;
using System.Net;
using Microsoft.Extensions.Logging;
using RYMtool.Core.Dtos.Responses;

namespace RYMtool.Core.Services;

public class AlbumService : IAlbumService
{
    private readonly IRepository<Album> _repository;
    private readonly IMapper _mapper;

    public AlbumService(IRepository<Album> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResponseAlbums> GetAllAlbumsAsync(string order)
    {
        if (string.IsNullOrWhiteSpace(order))
        {
            return new ResponseAlbums() { Code = HttpStatusCode.BadRequest, Text = "incorrect order", Albums = null };
        }

        var albums = await _repository.ListAsync(new AlbumGetAllOrderedQuery(order));
        var result = _mapper.Map<List<AlbumDto>>(albums);

        return new ResponseAlbums() { Code = HttpStatusCode.OK, Albums = result };
    }

    public async Task<Album> AddAsync(AlbumCreateDto albumDto)
    {
        var album = _mapper.Map<Album>(albumDto);
        return await _repository.AddAsync(album);
    }

    public async Task<ResponseAlbums> GetTenRecommendedAlbumsAsync(string genre)
    {
        if (string.IsNullOrWhiteSpace(genre))
        {
            return new ResponseAlbums() { Code = HttpStatusCode.BadRequest, Text = "incorrect genre", Albums = null };
        }

        var albums = await _repository.ListAsync(new AlbumGetTenRecommendedQuery(genre));
        var result = _mapper.Map<List<AlbumDto>>(albums);

        return new ResponseAlbums() { Code = HttpStatusCode.OK, Albums = result };
    }

    public async Task<ResponseAlbum> GetAlbumDetailAsync(int id)
    {
        var album = await _repository.GetByQueryAsync(new AlbumListReviewGetByIdQuery(id));

        if (album == null) 
        {
            return new ResponseAlbum() { Code = HttpStatusCode.NotFound, Text = "album not found", Album = null};
        }

        var result = _mapper.Map<AlbumListReviewDto>(album);
        return new ResponseAlbum() { Code = HttpStatusCode.OK, Album = result };
    }

    public async Task<HttpStatusCode> DeleteAlbumAsync(int id)
    {
        var album = await _repository.GetByIdAsync(id);

        if (album == null)
        {
            return HttpStatusCode.NotFound;
        }
         
        await _repository.DeleteAsync(album);
        return HttpStatusCode.OK;
    }
}