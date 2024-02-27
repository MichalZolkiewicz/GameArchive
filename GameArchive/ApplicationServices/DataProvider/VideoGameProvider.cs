using GameArchive.Data.Entities;
using GameArchive.Data.Repositories;

namespace GameArchive.ApplicationServices.DataProvider;

public class VideoGameProvider : IGameProvider<VideoGame>
{
    private readonly IRepository<VideoGame> _videoGameRepository;

    public VideoGameProvider(IRepository<VideoGame> videoGameRepository)
    {
        _videoGameRepository = videoGameRepository;
    }

    public int GetTheEarliestProducedGame()
    {
        var videoGames = _videoGameRepository.GetAll();
        var publicationYear = videoGames.Select(x => x.PublicationYear).Min();
        return publicationYear;
    }

    public List<string> GetUniqueGameProducer()
    {
        var videoGames = _videoGameRepository.GetAll();
        var producers = videoGames.Select(x => x.Producer).Distinct().ToList();
        return producers;
    }

    public List<VideoGame> OrderByName()
    {
        var videoGames = _videoGameRepository.GetAll();
        return videoGames.OrderBy(x => x.Name).ToList();
    }

    public List<VideoGame> WhereCategoryIs(string category)
    {
        var videoGames = _videoGameRepository.GetAll();
        return videoGames.Where(x => x.Category == category).ToList();
    }
}
