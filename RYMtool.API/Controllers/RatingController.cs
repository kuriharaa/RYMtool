using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RYMtool.Core.Dtos;
using RYMtool.Core.Models;
using RYMtool.Core.Services;

namespace RYMtool.API.Controllers;

[ApiController]
[Route("api")]
public class RatingController:ControllerBase
{
    private readonly IRatingService _reviewService;
    private readonly IMapper _mapper;

    public RatingController(
        IRatingService reviewService, 
        IMapper mapper)
    {
        _reviewService = reviewService;
        _mapper = mapper;
    }

    [HttpPost("albums/{id}/rating")]
    public async Task<IActionResult> SaveRating(RatingDto reviewDto,int id)
    {
        var review = _mapper.Map<Rating>(reviewDto);
        review.AlbumId = id;
        var res = await _reviewService.SaveRatingAsync(review);
        return Ok(new {res.Id});
    }
}