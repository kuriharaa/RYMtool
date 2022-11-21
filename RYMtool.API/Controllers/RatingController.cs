using Microsoft.AspNetCore.Mvc;
using RYMtool.Core.Dtos;
using RYMtool.Core.Models;
using RYMtool.Core.Services;

namespace RYMtool.API.Controllers;

[ApiController]
[Route("api")]
public class RatingController:ControllerBase
{
    private readonly IRatingService _ratingService;
    private readonly ILogger _logger;

    public RatingController(IRatingService ratingService, ILogger<RatingController> logger)
    {
        _ratingService = ratingService;
        _logger = logger;
    }

    [HttpPost("albums/{id}/rating")]
    public async Task<IActionResult> SaveRating([FromBody] RatingDto ratingDto, [FromRoute] int id)
    {
        var result = await _ratingService.SaveRatingAsync(ratingDto, id);
        if (result == null) 
        {
            _logger.LogWarning("album not found | id = {id}", id);
            return NotFound();
        }

        return Ok( new { result.Id });
    }
}