namespace RYMtool.Core.Models;

public class Album:IAggregateRoot
{
    public int Id { get; set; }
    public string Title { get; set; } = String.Empty;
    public string Cover { get; set; } = String.Empty;
    public string Descriptors { get; set; } = String.Empty;
    public string Artist { get; set; } = String.Empty;
    public string Genre { get; set; } = String.Empty;
    public List<Review>? Reviews { get; set; } = new();
    public List<Rating>? Ratings { get; set; }= new();

}