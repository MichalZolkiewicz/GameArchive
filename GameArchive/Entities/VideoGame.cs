namespace GameArchive.Entities;
public class VideoGame : EntityBase
{
    public string? OnlineOption { get; set; }

    public override string ToString() => $"Id: {Id}\nName: {Name}\nCategory: {Category}\nPublication year: {PublicationYear}\nProducer: {Producer}\n Multiplayer option: {OnlineOption}";
}
