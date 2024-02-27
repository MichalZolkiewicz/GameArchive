using GameArchive.Data.Entities;
using GameArchive.Data.Repositories;

namespace GameArchive.ApplicationServices.DataProvider;

public class BoardGameProvider : IGameProvider<BoardGame>
{
    private readonly IRepository<BoardGame> _boardGameRepository;

    public BoardGameProvider(IRepository<BoardGame> boardGameRepository)
    {
        _boardGameRepository = boardGameRepository;
    }
    public int GetTheEarliestProducedGame()
    {
        var boardGames = _boardGameRepository.GetAll();
        var publicationYear = boardGames.Select(x => x.PublicationYear).Min();
        return publicationYear;
    }

    public List<string> GetUniqueGameProducer()
    {
        var boardGames = _boardGameRepository.GetAll();
        var producers = boardGames.Select(x => x.Producer).Distinct().ToList();
        return producers;
    }

    public List<BoardGame> OrderByName()
    {
        var boardGames = _boardGameRepository.GetAll();
        return boardGames.OrderBy(x => x.Name).ToList();
    }

    public List<BoardGame> WhereCategoryIs(string category)
    {
        var boardGames = _boardGameRepository.GetAll();
        return boardGames.Where(x => x.Category == category).ToList();
    }
}
