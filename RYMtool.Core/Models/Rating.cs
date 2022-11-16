namespace RYMtool.Core.Models;

public class Rating:IAggregateRoot
{
    public int Id { get; set; }
    public int AlbumId { get; set; }
    public decimal Score { get; set; }
    public Album? Album { get; set; }
}