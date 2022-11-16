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
    private readonly IMapper _mapper;

    public ReviewController(
        IReviewService reviewService, 
        IMapper mapper)
    {
        _reviewService = reviewService;
        _mapper = mapper;
    }

    [HttpPost("albums/{id}/review")]
    public async Task<IActionResult> SaveReview(ReviewDto reviewDto,int id)
    {
        var review = _mapper.Map<Review>(reviewDto);
        review.AlbumId = id;
        var res = await _reviewService.SaveReviewAsync(review);
        return Ok(new {res.Id});
    }
}