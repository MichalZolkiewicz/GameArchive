using GameArchive.Data;
using GameArchive.Entities;
using GameArchive.Repositories;
using GameArchive.Repositories.Extensions;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace GameArchive.Logic;

public class GameArchiveLogic
{
    SqlRepository<VideoGame> videoGameRepository = new SqlRepository<VideoGame>(new GameArchiveDbContext());

    SqlRepository<BoardGame> boardGameRepository = new SqlRepository<BoardGame>(new GameArchiveDbContext());

    public SqlRepository<VideoGame> GetVideoGameRepository()
    {
        return videoGameRepository;
    }

    public SqlRepository<BoardGame> GetBoardGameRepository()
    {
        return boardGameRepository;
    }

    public void ChooseActionAndRepository(string typeInput, string actionInput)
    {
        if(typeInput == "1")
        {
            switch(actionInput)
            {
                case "A":
                case "a":
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
                    break;
                case "B":
                case "b":
                    Console.WriteLine("Insert game ID");
                    var gameId = ConvertStringToInteger(Console.ReadLine());
                    VideoGame videoGame1 = videoGameRepository.FindGamebyId(gameId);
                    Console.WriteLine(videoGame1.Name);
                    break;
                case "C": 
                case "c":
                    var videoGames = videoGameRepository.GetAll();
                    foreach(var videoGame2 in videoGames)
                    {
                        Console.WriteLine(videoGame2);
                        Console.WriteLine();
                    }
                    break;
                case "D":
                case "d":
                    Console.WriteLine("Insert game ID");
                    var gameId1 = ConvertStringToInteger(Console.ReadLine());
                    VideoGame videoGame3 = videoGameRepository.FindGamebyId(gameId1);
                    videoGameRepository.RemoveGame(videoGame3);
                    break;
                default:
                    throw new Exception("Wrong letter!");
            }
        }
        else if(typeInput == "2")
        {
            switch(actionInput)
            {
                case "A":
                case "a":
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

                    boardGameRepository.AddGame(boardGame);
                    break;
                case "B":
                case "b":
                    Console.WriteLine("Insert game ID");
                    var gameId = ConvertStringToInteger(Console.ReadLine());
                    BoardGame boardGame1 = boardGameRepository.FindGamebyId(gameId);
                    Console.WriteLine(boardGame1.Name);
                    break;
                case "C":
                case "c":
                    var boardGames = boardGameRepository.GetAll();
                    foreach (var boardGame2 in boardGames)
                    {
                        Console.WriteLine(boardGame2);
                        Console.WriteLine();
                    }
                    break;
                case "D":
                case "d":
                    Console.WriteLine("Insert game ID");
                    var gameId1 = ConvertStringToInteger(Console.ReadLine());
                    BoardGame boardGame3 = boardGameRepository.FindGamebyId(gameId1);
                    boardGameRepository.RemoveGame(boardGame3);
                    break;
                default:
                    throw new Exception("Wrong letter!");
            }
        }
        else
        {
            throw new Exception("Wrong number!");
        }
    }
    
    public Boolean ConvertStringToBoolean(string input)
    {
        if(input == "yes")
        {
            return true;
        }
        else if(input == "no")
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
        if(int.TryParse(input, out int result))
        {
            return result;
        }
        else
        {
            throw new Exception("String is not a integer!");
        }
    }
}
