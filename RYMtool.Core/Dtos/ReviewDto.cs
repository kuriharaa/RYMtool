using AutoMapper;
using RYMtool.Core.Dtos.Responses;
using RYMtool.Core.Models;

namespace RYMtool.Core.Dtos;

public class ReviewDto : Response, IMap
{
    public string Message { get; set; } = String.Empty;
    public string Reviewer { get; set; } = String.Empty;
    public void Mapping(Profile profile)
    {
        profile.CreateMap<ReviewDto, Review>();
    }
}