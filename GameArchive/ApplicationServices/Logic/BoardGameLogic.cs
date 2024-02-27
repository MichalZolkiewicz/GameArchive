using GameArchive.ApplicationServices.Logic.Extension;
using GameArchive.Data.Entities;
using GameArchive.Data.Repositories;

namespace GameArchive.ApplicationServices.Logic;

public class BoardGameLogic : IGameLogic<BoardGame>
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
        var gamePublicationYear = GameLogicExtension.ConvertStringToInteger(Console.ReadLine());
        Console.WriteLine("Insert producer");
        var gameProducer = Console.ReadLine();
        Console.WriteLine("Insert maximum amount of players");
        var maxPlayers = GameLogicExtension.ConvertStringToInteger(Console.ReadLine());
        BoardGame boardGame = new BoardGame { Name = gameName, Category = gameCategory, PublicationYear = gamePublicationYear, Producer = gameProducer, MaxPlayers = maxPlayers };

        _boardGameRepository.ItemAdded += _eventLoggerLogic.GameRepositoryOnItemAdded;
        _boardGameRepository.Add(boardGame);
        _boardGameRepository.Save();
    }

    public void DisplayGameById()
    {
        Console.WriteLine("Insert game ID");
        var gameId = GameLogicExtension.ConvertStringToInteger(Console.ReadLine());
        BoardGame boardGame = _boardGameRepository.GetById(gameId);
        if (boardGame != null)
        {
            Console.WriteLine(boardGame.Name);

        }
        else
        {
            throw new Exception("Id number does not exist!");
        }
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

    public void UpdateGame(string id)
    {

        var boardGame = _boardGameRepository.GetById(GameLogicExtension.ConvertStringToInteger(id));
        Console.WriteLine("=========================================");
        Console.WriteLine("What would you like to change?");
        Console.WriteLine("\nA => Name\nB => Category\nC => Publication year\nD => Producer\nE => Online option");
        var input = Console.ReadLine().ToUpper();
        if (boardGame != null)
        {
            switch (input)
            {
                case "A":
                    Console.WriteLine("Insert new name");
                    var name = Console.ReadLine();
                    boardGame.Name = name;
                    break;
                case "B":
                    Console.WriteLine("Insert new category");
                    var category = Console.ReadLine();
                    boardGame.Category = category;
                    break;
                case "C":
                    Console.WriteLine("Insert new publication year");
                    var publicationYear = Console.ReadLine();
                    boardGame.PublicationYear = GameLogicExtension.ConvertStringToInteger(publicationYear);
                    break;
                case "D":
                    Console.WriteLine("Insert new producer");
                    var producer = Console.ReadLine();
                    boardGame.Producer = producer;
                    break;
                case "E":
                    Console.WriteLine("Insert maximum amout of players");
                    var maxPlayers = Console.ReadLine();
                    boardGame.MaxPlayers = GameLogicExtension.ConvertStringToInteger(maxPlayers);
                    break;
                default:
                    throw new Exception("Wrong letter!");
            }
        }
        Console.WriteLine($"Game with Id: {id} updated");
        _boardGameRepository.Save();
    }

    public void RemoveGame()
    {
        Console.WriteLine("Insert game ID");
        var gameId = GameLogicExtension.ConvertStringToInteger(Console.ReadLine());
        BoardGame boardGame = _boardGameRepository.GetById(gameId);
        if (boardGame != null)
        {
            _boardGameRepository.ItemRemoved += _eventLoggerLogic.GameRepositoryOnItemRemoved;
            _boardGameRepository.Remove(boardGame);
            _boardGameRepository.Save();
            Console.WriteLine($"Game with Id: {gameId} removed");
        }
        else
        {
            throw new Exception("Id number does not exist!");
        }   
    }
}
