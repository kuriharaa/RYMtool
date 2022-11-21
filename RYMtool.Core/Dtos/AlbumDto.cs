using AutoMapper;
using RYMtool.Core.Dtos.Responses;
using RYMtool.Core.Models;
using System.Net;

namespace RYMtool.Core.Dtos;

public class AlbumDto : Response, IMap
{
    public int Id { get; set; }
    public string Title { get; set; } = String.Empty;
    public string Artist { get; set; } = String.Empty;
    public decimal Rating { get; set; }
    public decimal ReviewsNumber { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Album, AlbumDto>()
            .ForMember(dest => dest.ReviewsNumber, map =>
                map.MapFrom(s => s.Reviews!.Count))
            .ForMember(dest => dest.Rating, map =>
                map.MapFrom(s => s.Reviews != null && s.Reviews.Count==0?0:s.Ratings.Sum(x => x.Score) / s.Ratings.Count));
        profile.CreateMap<AlbumDto, Album>();
    }
}