namespace GameArchive.Data;

using GameArchive.Data.Entities;
using Microsoft.EntityFrameworkCore;

public class GameArchiveDbContext : DbContext
{
    public DbSet<VideoGame> VideoGames => Set<VideoGame>();
    public DbSet<BoardGame> BoardGames => Set<BoardGame>();

    public string conString = "Data Source=LAPTOP-AJM90S2R;Initial Catalog=GameArchiveDb;Integrated Security=True;Encrypt=False";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(conString);
    }
}
