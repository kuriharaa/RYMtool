using RYMtool.Core.Models;

namespace RYMtool.Core.Services;

public interface IRatingService:IService
{
    Task<Rating> SaveRatingAsync(Rating review);
}