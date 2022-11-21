using RYMtool.Core.Dtos;
using RYMtool.Core.Models;

namespace RYMtool.Core.Services;

public interface IRatingService:IService
{
    Task<Rating?> SaveRatingAsync(RatingDto ratingDto, int id);
}