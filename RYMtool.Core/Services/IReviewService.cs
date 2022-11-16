using RYMtool.Core.Models;

namespace RYMtool.Core.Services;

public interface IReviewService:IService
{
    Task<Review> SaveReviewAsync(Review review);
}