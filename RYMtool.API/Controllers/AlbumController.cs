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
    public async Task<IActionResult> GetAlbums([FromQuery] string order)
    {
        var albums = await _albumService.GetAllAlbumsAsync(order);
        var result = _mapper.Map<List<AlbumDto>>(albums);
        return Ok(result);
    } 

    [HttpGet("/recommended")]
    public async Task<IActionResult> GetTenRecommendedAlbums([FromQuery] string genre)
    {
        var albums = await _albumService.GetTenRecommendedAlbumsAsync(genre);
        var result = _mapper.Map<List<AlbumDto>>(albums);
        return Ok(result);
    }  

    [HttpGet("/albums/{id}")]
    public async Task<IActionResult> GetAlbumDetail([FromRoute] int id)
    {
        var album = await _albumService.GetAlbumDetailAsync(id);
        var result = _mapper.Map<AlbumListReviewDto>(album);
        return Ok(result);
    }

    [HttpDelete("/albums/{id}/")]
    public async Task<IActionResult> DeleteAlbum([FromRoute] int id, [FromQuery] string secret)
    {
        if (secret != _appSettings.SecretKey) 
        {
            return BadRequest();
        }

        await _albumService.DeleteAlbumAsync(id);
        return Ok();
    } 
   
    [HttpPost("/albums/save")]
    public async Task<IActionResult> SaveAlbum(AlbumCreateDto albumDto)
    {
        var album = _mapper.Map<Album>(albumDto);
        var result = await _albumService.AddAsync(album);
        return Ok(new { result.Id });
    }
}