namespace GameArchive.Entities;

public interface IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public int PublicationYear { get; set; }
    public string Producer { get; set; }

}
