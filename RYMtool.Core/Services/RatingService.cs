using RYMtool.Core.Exceptions;
using RYMtool.Core.Interfaces;
using RYMtool.Core.Models;

namespace RYMtool.Core.Services;

public class RatingService:IRatingService
{
    private readonly IRepository<Rating> _repository;
    private readonly IRepository<Album> _albumrepository;

    public RatingService(
        IRepository<Rating> repository, 
        IRepository<Album> albumrepository)
    {
        _repository = repository;
        _albumrepository = albumrepository;
    }

    public async Task<Rating> SaveRatingAsync(Rating rating)
    {
        var album = await _albumrepository.GetByIdAsync(rating.AlbumId);
        if (album == null)
            throw new NotFoundException(nameof(album), rating.Id);
        return await _repository.AddAsync(rating);
    }
}