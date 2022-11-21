using RYMtool.Core.Dtos;
using RYMtool.Core.Exceptions;
using RYMtool.Core.Interfaces;
using RYMtool.Core.Models;
using RYMtool.Core.Queries.AlbumQueries;
using AutoMapper;
using System.Net;
using Microsoft.Extensions.Logging;

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

    public async Task<List<AlbumDto>> GetAllAlbumsAsync(string order)
    {
        var albums = await _repository.ListAsync(new AlbumGetAllOrderedQuery(order));
        var result = _mapper.Map<List<AlbumDto>>(albums);

        return result;
    }

    public async Task<Album> AddAsync(AlbumCreateDto albumDto)
    {
        var album = _mapper.Map<Album>(albumDto);
        return await _repository.AddAsync(album);
    }

    public async Task<List<AlbumDto>> GetTenRecommendedAlbumsAsync(string genre)
    {
        var albums = await _repository.ListAsync(new AlbumGetTenRecommendedQuery(genre));
        var result = _mapper.Map<List<AlbumDto>>(albums);

        return result;
    }

    public async Task<AlbumListReviewDto?> GetAlbumDetailAsync(int id)
    {
        var album = await _repository.GetByQueryAsync(new AlbumListReviewGetByIdQuery(id));

        if (album == null) 
        {
            return null;
        }

        var result = _mapper.Map<AlbumListReviewDto>(album);
        return result;
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