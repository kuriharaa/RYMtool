using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RYMtool.Core.Dtos;
using RYMtool.Core.Models;
using RYMtool.Core.Services;

namespace RYMtool.API.Controllers;
[ApiController]
[Route("api")]
public class ReviewController:ControllerBase
{
    private readonly IReviewService _reviewService;
    private readonly ILogger _logger;

    public ReviewController(IReviewService reviewService, ILogger<ReviewController> logger)
    {
        _reviewService = reviewService;
        _logger = logger;
    }

    [HttpPost("albums/{id}/review")]
    public async Task<IActionResult> SaveReview([FromBody] ReviewDto reviewDto, [FromRoute] int id)
    {
        var result = await _reviewService.SaveReviewAsync(reviewDto, id);
        if (result == null)
        {
            _logger.LogWarning("album not found | id = {id}", id);
            return NotFound();
        }

        return Ok( new { result.Id } );
    }
}