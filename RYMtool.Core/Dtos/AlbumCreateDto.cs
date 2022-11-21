using AutoMapper;
using RYMtool.Core.Dtos.Responses;
using RYMtool.Core.Models;

namespace RYMtool.Core.Dtos;

public class AlbumCreateDto : Response, IMap
{
    public int Id { get; set; }
    public string Title { get; set; } = String.Empty;
    public string Cover { get; set; } = String.Empty;
    public string Descriptors { get; set; } = String.Empty;
    public string Genre { get; set; } = String.Empty;
    public string Artist { get; set; } = String.Empty;
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<AlbumCreateDto, Album>();
    }
}