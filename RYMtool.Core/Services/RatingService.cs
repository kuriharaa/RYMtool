using AutoMapper;
using RYMtool.Core.Dtos;
using RYMtool.Core.Exceptions;
using RYMtool.Core.Interfaces;
using RYMtool.Core.Models;

namespace RYMtool.Core.Services;

public class RatingService:IRatingService
{
    private readonly IRepository<Rating> _repository;
    private readonly IRepository<Album> _albumrepository;
    private readonly IMapper _mapper;

    public RatingService(
        IRepository<Rating> repository, 
        IRepository<Album> albumrepository,
        IMapper mapper)
    {
        _repository = repository;
        _albumrepository = albumrepository;
        _mapper = mapper;
    }

    public async Task<Rating?> SaveRatingAsync(RatingDto ratingDto, int id)
    {
        var rating = _mapper.Map<Rating>(ratingDto);
        rating.AlbumId = id;

        var album = await _albumrepository.GetByIdAsync(rating.AlbumId);

        if (album == null)
        {
            return null;
        }

        return await _repository.AddAsync(rating);
    }
}