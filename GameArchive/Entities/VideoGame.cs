namespace GameArchive.Entities;
public class VideoGame : EntityBase
{
    public string? Name { get; set; }
    public string? Category { get; set; }
    public int PublicationYear { get; set; }
    public string? Producer { get; set; }
    public Boolean? OnlineOption { get; set; }

    public override string ToString() => $"Id: {Id}\nName: {Name}\nCategory: {Category}\nPublication year: {PublicationYear}\nProducer: {Producer}\nMultiplayer option: {OnlineOption}";
}
