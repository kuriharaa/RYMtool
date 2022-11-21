using Microsoft.AspNetCore.Mvc;
using RYMtool.Core.Dtos;
using RYMtool.Core.Exceptions;
using RYMtool.Core.Models;
using RYMtool.Core.Services;
using System.Net;

namespace RYMtool.API.Controllers;

[ApiController]
[Route("api")]
public class AlbumController : ControllerBase
{
    private readonly IAlbumService _albumService;
    private readonly AppSettings _appSettings;
    private readonly ILogger _logger;

    public AlbumController(IAlbumService albumService, AppSettings appSettings, ILogger<AlbumController> logger)
    {
        _albumService = albumService;
        _appSettings = appSettings;
        _logger = logger;
    }

    [HttpGet("/albums")]
    public async Task<IActionResult> GetAlbums([FromQuery] string order)
    {
        return Ok(await _albumService.GetAllAlbumsAsync(order));
    } 

    [HttpGet("/recommended")]
    public async Task<IActionResult> GetTenRecommendedAlbums([FromQuery] string genre)
    {
        return Ok(await _albumService.GetTenRecommendedAlbumsAsync(genre));
    }  

    [HttpGet("/albums/{id}")]
    public async Task<IActionResult> GetAlbumDetail([FromRoute] int id)
    {
        var album = await _albumService.GetAlbumDetailAsync(id);

        if (album == null) 
        {
            _logger.LogWarning("album not found | id = {id}", id);
            return NotFound();
        }

        return Ok(album);
    }

    [HttpDelete("/albums/{id}/")]
    public async Task<IActionResult> DeleteAlbum([FromRoute] int id, [FromQuery] string secret)
    {
        if (secret != _appSettings.SecretKey) 
        {
            _logger.LogWarning("invalid key | key = {secret}", secret);
            return BadRequest();
        }

        var statusCode = await _albumService.DeleteAlbumAsync(id);
        if (statusCode == HttpStatusCode.NotFound) 
        {
            _logger.LogWarning("album not found | id = {id}", id);
            return NotFound();
        }

        _logger.LogInformation("album was deleted... | id = {id}", id);
        return Ok();
    } 
   
    [HttpPost("/albums/save")]
    public async Task<IActionResult> SaveAlbum([FromBody] AlbumCreateDto albumDto)
    {
        var result = await _albumService.AddAsync(albumDto);
        return Ok(new { result.Id });
    }
}