using AutoMapper;
using RYMtool.Core.Dtos;
using RYMtool.Core.Exceptions;
using RYMtool.Core.Interfaces;
using RYMtool.Core.Models;
using RYMtool.Core.Queries;

namespace RYMtool.Core.Services;

public class ReviewService : IReviewService
{
    private readonly IRepository<Review> _repository;
    private readonly IRepository<Album> _albumRepository;
    private readonly IMapper _mapper;

    public ReviewService(
        IRepository<Review> repository, 
        IRepository<Album> albumRepository,
        IMapper mapper)
    {
        _repository = repository;
        _albumRepository = albumRepository;
        _mapper = mapper; 
    }

    public async Task<Review?> SaveReviewAsync(ReviewDto reviewDto, int id)
    {
        var review = _mapper.Map<Review>(reviewDto);
        review.AlbumId = id;

        var album = await _albumRepository.GetByIdAsync(review.AlbumId);
        if (album == null) 
        {
            return null;
        }

        return await _repository.AddAsync(review);
    }
}