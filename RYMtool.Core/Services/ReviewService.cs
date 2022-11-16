using RYMtool.Core.Dtos;
using RYMtool.Core.Exceptions;
using RYMtool.Core.Interfaces;
using RYMtool.Core.Models;
using RYMtool.Core.Queries;

namespace RYMtool.Core.Services;

public class ReviewService:IReviewService
{
    private readonly IRepository<Review> _repository;
    private readonly IRepository<Album> _albumRepository;

    public ReviewService(
        IRepository<Review> repository, 
        IRepository<Album> albumRepository)
    {
        _repository = repository;
        _albumRepository = albumRepository;
    }

    public async Task<Review> SaveReviewAsync(Review review)
    {
        var album = await _albumRepository.GetByIdAsync(review.AlbumId);
        if (album == null)
            throw new NotFoundException(nameof(album), review.Id);
        return await _repository.AddAsync(review);
    }
}