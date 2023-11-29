namespace GameArchive.Data;

using GameArchive.Entities;
using Microsoft.EntityFrameworkCore;

public class GameArchiveDbContext : DbContext
{
    public DbSet<VideoGame> VideoGames => Set<VideoGame>();
    public DbSet<BoardGame> BoardGames => Set<BoardGame>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseInMemoryDatabase("GameArchiveDb");
    }
}
