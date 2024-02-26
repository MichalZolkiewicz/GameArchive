using GameArchive.Data.Entities;
using GameArchive.Data.Repositories;
using GameArchive.Logic.Extension;

namespace GameArchive.Logic;

public class VideoGameLogic : IGameLogic<VideoGame>
{
    private readonly IRepository<VideoGame> _videoGameRepository;
    private readonly IEventLoggerLogic _eventLoggerLogic;

    public VideoGameLogic(IRepository<VideoGame> videoGameRepository, IEventLoggerLogic eventLoggerLogic)
    {
        _videoGameRepository = videoGameRepository;
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
        Console.WriteLine("Insert if there is online option");
        var hasOnlineOption = GameLogicExtension.ConvertStringToBoolean(Console.ReadLine());
        VideoGame videoGame = new VideoGame { Name = gameName, Category = gameCategory, PublicationYear = gamePublicationYear, Producer = gameProducer, OnlineOption = hasOnlineOption };

        _videoGameRepository.ItemAdded += _eventLoggerLogic.GameRepositoryOnItemAdded;
        _videoGameRepository.Add(videoGame);
        _videoGameRepository.Save();
    }

    public void DisplayGameById()
    {
        Console.WriteLine("Insert game ID");
        var gameId = GameLogicExtension.ConvertStringToInteger(Console.ReadLine());
        VideoGame videoGame = _videoGameRepository.GetById(gameId);
        Console.WriteLine(videoGame.Name);
    }

    public void DisplayAllGames()
    {
        var videoGames = _videoGameRepository.GetAll();
        foreach (var videoGame in videoGames)
        {
            Console.WriteLine(videoGame);
            Console.WriteLine();
        }
    }

    public void UpdateGame(string id)
    {
        var videoGame = _videoGameRepository.GetById(GameLogicExtension.ConvertStringToInteger(id));
        Console.WriteLine("=========================================");
        Console.WriteLine("What would you like to change?");
        Console.WriteLine("\nA => Name\nB => Category\nC => Publication year\nD => Producer\nE => Online option");
        var input = Console.ReadLine().ToUpper();
        if (videoGame != null)
        {
            switch (input)
            {
                case "A":
                    Console.WriteLine("Insert new name");
                    var name = Console.ReadLine();
                    videoGame.Name = name;
                    break;
                case "B":
                    Console.WriteLine("Insert new category");
                    var category = Console.ReadLine();
                    videoGame.Category = category;
                    break;
                case "C":
                    Console.WriteLine("Insert new publication year");
                    var publicationYear = Console.ReadLine();
                    videoGame.PublicationYear = GameLogicExtension.ConvertStringToInteger(publicationYear);
                    break;
                case "D":
                    Console.WriteLine("Insert new producer");
                    var producer = Console.ReadLine();
                    videoGame.Producer = producer;
                    break;
                case "E":
                    Console.WriteLine("Insert if online option is available");
                    var onlineOption = Console.ReadLine();
                    videoGame.OnlineOption = GameLogicExtension.ConvertStringToBoolean(onlineOption);
                    break;
                default:
                    throw new Exception("Wrong letter!");
            }
        }

        _videoGameRepository.Save();
    }

    public void RemoveGame()
    {
        Console.WriteLine("Insert game ID");
        var gameId = GameLogicExtension.ConvertStringToInteger(Console.ReadLine());
        VideoGame videoGame = _videoGameRepository.GetById(gameId);
        _videoGameRepository.ItemRemoved += _eventLoggerLogic.GameRepositoryOnItemRemoved;
        _videoGameRepository.Remove(videoGame);
        _videoGameRepository.Save();
    }
}
