using GameArchive.Data;
using GameArchive.Entities;
using GameArchive.Repositories;
using GameArchive.Repositories.Extensions;

namespace GameArchive.Logic;

internal class VideoGameLogic
{
    SqlRepository<VideoGame> videoGameRepository = new SqlRepository<VideoGame>(new GameArchiveDbContext());

    public void AddVideoGame()
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

        videoGameRepository.AddGame(videoGame);
    }

    public void DisplayVideoGameById()
    {
        Console.WriteLine("Insert game ID");
        var gameId = ConvertStringToInteger(Console.ReadLine());
        VideoGame videoGame = videoGameRepository.FindGameById(gameId);
        Console.WriteLine(videoGame.Name);
    }

    public void DisplayAllVideoGames()
    {
        var videoGames = videoGameRepository.GetAll();
        foreach (var videoGame in videoGames)
        {
            Console.WriteLine(videoGame);
            Console.WriteLine();
        }
    }

    public void RemoveVideoGame()
    {
        Console.WriteLine("Insert game ID");
        var gameId = ConvertStringToInteger(Console.ReadLine());
        VideoGame videoGame = videoGameRepository.FindGameById(gameId);
        videoGameRepository.RemoveGame(videoGame);
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
