using GameArchive.Data.DataProvider;
using GameArchive.Data.Entities;
using System.Collections.Concurrent;

namespace GameArchive.Logic;

public class GameArchiveLogic
{
    private readonly VideoGameLogic videoGameLogic = new VideoGameLogic();
    private readonly BoardGameLogic boardGameLogic = new BoardGameLogic();

    private readonly IGameProvider<VideoGame> _videoGameProvider;
    private readonly IGameProvider<BoardGame> _boardGameProvider;

    public GameArchiveLogic(IGameProvider<VideoGame> videoGameProvider, IGameProvider<BoardGame> boardGameProvider )
    {
        _videoGameProvider = videoGameProvider;
        _boardGameProvider = boardGameProvider;
    }
    public void ChooseActionAndRepository(string typeInput)
    {
        if (typeInput == "1")
        {
            Console.WriteLine("\nChoose action:\nA => Add game\nB => Display game\nC => Display all games\nD => Remove Game" +
                              "\nE => Show earliest produced game\nF => Show unique producers\nG => Order by name\nH => Filter by category name");
            Console.WriteLine();
            var input2 = Console.ReadLine();


            switch (input2)
            {
                case "A":
                case "a":
                    videoGameLogic.AddVideoGame();
                    break;
                case "B":
                case "b":
                    videoGameLogic.DisplayVideoGameById();
                    break;
                case "C": 
                case "c":
                    videoGameLogic.DisplayAllVideoGames();
                    break;
                case "D":
                case "d":
                    videoGameLogic.RemoveVideoGame();
                    break;
                case "E":
                case "e":                    
                    Console.WriteLine(_videoGameProvider.GetTheEarliestProducedGame());
                    break;
                case "F":
                case "f":                    
                    foreach(var producer in _videoGameProvider.GetUniqueGameProducer())
                    {
                        Console.WriteLine(producer);
                    }
                    break;
                case "G":
                case "g":
                    foreach (var game in _videoGameProvider.OrderByName())
                    {
                        Console.WriteLine(game);
                    }
                    break;
                case "H":
                case "h":
                    string category = Console.ReadLine();
                    foreach (var game in _videoGameProvider.WhereCategoryIs(category))
                    {
                        Console.WriteLine(game);
                    }
                    break;
                default:
                    throw new Exception("Wrong letter!");
            }
        }
        else if(typeInput == "2")
        {
            Console.WriteLine("\nChoose action:\nA => Add game\nB => Display game\nC => Display all games\nD => Remove Game" +
                "\nE => Show earliest produced game\nF => Show unique producers\nG => Order by name\nH => Filter by category name");
            Console.WriteLine();
            var input2 = Console.ReadLine();
            switch (input2)
            {
                case "A":
                case "a":
                    boardGameLogic.AddBoardGame();
                    break;
                case "B":
                case "b":
                    boardGameLogic.DisplayBoardGameById();
                    break;
                case "C":
                case "c":
                    boardGameLogic.DisplayAllBoardGames();
                    break;
                case "D":
                case "d":
                    boardGameLogic.RemoveBoardGame();
                    break;
                case "E":
                case "e":                   
                    Console.WriteLine(_boardGameProvider.GetTheEarliestProducedGame());
                    break;
                case "F":
                case "f":
                    foreach (var producer in _boardGameProvider.GetUniqueGameProducer())
                    {
                        Console.WriteLine(producer);
                    }
                    break;
                case "G":
                case "g":
                    foreach (var game in _boardGameProvider.OrderByName())
                    {
                        Console.WriteLine(game);
                    }
                    break;
                case "H":
                case "h":
                    string category = Console.ReadLine();
                    foreach (var game in _boardGameProvider.WhereCategoryIs(category))
                    {
                        Console.WriteLine(game);
                    }
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
}
