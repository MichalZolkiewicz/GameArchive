using GameArchive.Data.Entities;
using GameArchive.Data.Repositories;

namespace GameArchive.Logic;

public class VideoGameLogic<T> : IGameLogic <T> where T : class
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
        var gamePublicationYear = ConvertStringToInteger(Console.ReadLine());
        Console.WriteLine("Insert producer");
        var gameProducer = Console.ReadLine();
        Console.WriteLine("Insert if there is online option");
        var gameOnlineOption = ConvertStringToBoolean(Console.ReadLine());
        VideoGame videoGame = new VideoGame { Name = gameName, Category = gameCategory, PublicationYear = gamePublicationYear, Producer = gameProducer, OnlineOption = gameOnlineOption };

        _videoGameRepository.ItemAdded += _eventLoggerLogic.GameRepositoryOnItemAdded;
        _videoGameRepository.Add(videoGame);
        _videoGameRepository.Save();
    }

    public void DisplayGameById()
    {
        Console.WriteLine("Insert game ID");
        var gameId = ConvertStringToInteger(Console.ReadLine());
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

    public void RemoveGame()
    {
        Console.WriteLine("Insert game ID");
        var gameId = ConvertStringToInteger(Console.ReadLine());
        VideoGame videoGame = _videoGameRepository.GetById(gameId);
        //_videoGameRepository.ItemRemoved += EventLoggerLogic.GameRepositoryOnItemRemoved;
        _videoGameRepository.Remove(videoGame);
        _videoGameRepository.Save();
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
