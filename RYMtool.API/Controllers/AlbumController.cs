using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RYMtool.Core.Dtos;
using RYMtool.Core.Exceptions;
using RYMtool.Core.Models;
using RYMtool.Core.Services;

namespace RYMtool.API.Controllers;

[ApiController]
[Route("api")]
public class AlbumController : ControllerBase
{
    private readonly IAlbumService _albumService;
    private readonly IMapper _mapper;
    private readonly AppSettings _appSettings;

    public AlbumController(
        IAlbumService albumService, 
        IMapper mapper, 
        AppSettings appSettings)
    {
        _albumService = albumService;
        _mapper = mapper;
        _appSettings = appSettings;
    }

    [HttpGet("/albums")]
    public async Task<IActionResult> GetAlbums([FromQuery]string? order = default)
    {
        var albums = await _albumService.GetAllAlbumsAsync(order);
        var res = _mapper.Map<List<AlbumDto>>(albums);
        return Ok(res);
    } 
    [HttpGet("/recommended")]
    public async Task<IActionResult> GetTenRecommendedAlbums([FromQuery]string? genre = default)
    {
        var albums = await _albumService.GetTenRecommendedAlbumsAsync(genre);
        var res = _mapper.Map<List<AlbumDto>>(albums);
        return Ok(res);
    }  
    [HttpGet("/albums/{id}")]
    public async Task<IActionResult> GetAlbumDetail(int id)
    {
        var album = await _albumService.GetAlbumDetailAsync(id);
        var res = _mapper.Map<AlbumListReviewDto>(album);
        return Ok(res);
    }  
    [HttpDelete("/albums/{id}/")]
    public async Task<IActionResult> DeleteAlbum(int id ,[FromQuery]string secret)
    {
        if (secret != _appSettings.SecretKey)
            throw new ProvidedSecretKeyIsNotValidException(secret);

        await _albumService.DeleteAlbumAsync(id);
        return Ok();
    } 
   
    [HttpPost("/albums/save")]
    public async Task<IActionResult> SaveAlbum(AlbumCreateDto albumDto)
    {
        var album = _mapper.Map<Album>(albumDto);
        var res = await _albumService.AddAsync(album);
        return Ok(new {res.Id});
    }
}