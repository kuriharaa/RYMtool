using AutoMapper;
using RYMtool.Core.Models;

namespace RYMtool.Core.Dtos;

public class AlbumListReviewDto:IMap
{
    public record AlbumReview(int Id, string Message, string Reviewer);
    public int Id { get; set; }
    public string Title { get; set; } = String.Empty;
    public string Artist { get; set; } = String.Empty;
    public decimal Rating { get; set; }
    public List<AlbumReview> Reviews { get; set; } = new();
    

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Album, AlbumListReviewDto>()
            .ForMember(dest => dest.Reviews, map =>
                map.MapFrom(s => s.Reviews.Select(x => new AlbumReview(x.Id,x.Message,x.Reviewer))))
            .ForMember(dest => dest.Rating, map =>
                map.MapFrom(s => s.Reviews.Count==0?0:s.Ratings.Sum(x => x.Score) / s.Ratings.Count));
        profile.CreateMap<AlbumDto, Album>();
    }
}