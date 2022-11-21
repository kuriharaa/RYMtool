using AutoMapper;
using RYMtool.Core.Dtos.Responses;
using RYMtool.Core.Models;

namespace RYMtool.Core.Dtos;

public class RatingDto : Response, IMap
{
    public decimal Score { get; set; } 
    public void Mapping(Profile profile)
    {
        profile.CreateMap<RatingDto, Rating>();
    }
}