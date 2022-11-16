namespace RYMtool.Core.Models;

public class Review:IAggregateRoot
{
    public int Id { get; set; }
    public string Message { get; set; } = String.Empty;
    public int AlbumId { get; set; }
    public string Reviewer { get; set; } = String.Empty;
    public Album? Album { get; set; } 
} 