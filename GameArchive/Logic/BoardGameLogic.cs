using GameArchive.Data.Entities;
using GameArchive.Data.Repositories;

namespace GameArchive.Logic;

public class BoardGameLogic<T> : IGameLogic <T> where T : class
{
    private readonly IRepository<BoardGame> _boardGameRepository;
    private readonly IEventLoggerLogic _eventLoggerLogic;

    public BoardGameLogic(IRepository<BoardGame> boardGameRepository, IEventLoggerLogic eventLoggerLogic)
    {
        _boardGameRepository = boardGameRepository;
        _eventLoggerLogic = eventLoggerLogic;
    }

    public void AddGame()
    {
        Console.WriteLine("Insert name");
        var gameName = Console.ReadLine();
        Console.WriteLine("Insert category");
        var gameCategory = Console.ReadLine();
        Console.WriteLine("Insert publication year");
        var gamePublicationYear = ConvertStringToInteger(Console.ReadLine());
        Console.WriteLine("Insert producer");
        var gameProducer = Console.ReadLine();
        Console.WriteLine("Insert maximum amount of players");
        var maxPlayers = ConvertStringToInteger(Console.ReadLine());
        BoardGame boardGame = new BoardGame { Name = gameName, Category = gameCategory, PublicationYear = gamePublicationYear, Producer = gameProducer, MaxPlayers = maxPlayers };

        _boardGameRepository.ItemAdded += _eventLoggerLogic.GameRepositoryOnItemAdded;
        _boardGameRepository.Add(boardGame);
        _boardGameRepository.Save();
    }

    public void DisplayGameById()
    {
        Console.WriteLine("Insert game ID");
        var gameId = ConvertStringToInteger(Console.ReadLine());
        BoardGame boardGame = _boardGameRepository.GetById(gameId);
        Console.WriteLine(boardGame.Name);
    }

    public void DisplayAllGames()
    {
        var boardGames = _boardGameRepository.GetAll();
        foreach (var boardGame in boardGames)
        {
            Console.WriteLine(boardGame);
            Console.WriteLine();
        }
    }

    public void RemoveGame()
    {
        Console.WriteLine("Insert game ID");
        var gameId = ConvertStringToInteger(Console.ReadLine());
        BoardGame boardGame = _boardGameRepository.GetById(gameId);
        _boardGameRepository.ItemRemoved += _eventLoggerLogic.GameRepositoryOnItemRemoved;
        _boardGameRepository.Remove(boardGame);
        _boardGameRepository.Save();
    }
    public Boolean ConvertStringToBoolean(string input)
    {
        if (input == "yes")
        {
            return true;
        }
        else if (input == "no")
        {
            return false;
        }
        else
        {
            throw new Exception("Incorrect wording!");
        }
    }

    public int ConvertStringToInteger(string input)
    {
        if (int.TryParse(input, out int result))
        {
            return result;
        }
        else
        {
            throw new Exception("String is not a integer!");
        }
    }
}
