namespace GameArchive.Entities;
public class BoardGame : EntityBase
{
    public int MaxPlayers { get; set; }

    public override string ToString() => $"Id: {Id}\nName: {Name}\nCategory: {Category}\nPublication year: {PublicationYear}\nProducer: {Producer}\n Multiplayer option: {MaxPlayers}";

}
