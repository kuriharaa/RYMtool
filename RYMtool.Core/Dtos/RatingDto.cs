using AutoMapper;
using RYMtool.Core.Models;

namespace RYMtool.Core.Dtos;

public class RatingDto:IMap
{
    public decimal Score { get; set; } 
    public void Mapping(Profile profile)
    {
        profile.CreateMap<RatingDto, Rating>();
    }
}