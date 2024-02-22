using GameArchive.Data.DataProvider;
using GameArchive.Data.Entities;

namespace GameArchive.Logic;

public class GameArchiveLogic : IGameArchiveLogic
{
    private readonly IGameLogic<VideoGame> _videoGameLogic;
    private readonly IGameLogic<BoardGame> _boardGameLogic;

    private readonly IGameProvider<VideoGame> _videoGameProvider;
    private readonly IGameProvider<BoardGame> _boardGameProvider;

    public GameArchiveLogic(IGameProvider<VideoGame> videoGameProvider, IGameProvider<BoardGame> boardGameProvider,
        IGameLogic<VideoGame> videoGameLogic, IGameLogic<BoardGame> boardGameLogic)
    {
        _videoGameProvider = videoGameProvider;
        _boardGameProvider = boardGameProvider;
        _videoGameLogic = videoGameLogic;
        _boardGameLogic = boardGameLogic;
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
                    _videoGameLogic.AddGame();
                    break;
                case "B":
                case "b":
                    _videoGameLogic.DisplayGameById();
                    break;
                case "C": 
                case "c":
                    _videoGameLogic.DisplayAllGames();
                    break;
                case "D":
                case "d":
                    _videoGameLogic.RemoveGame();
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
                    _boardGameLogic.AddGame();
                    break;
                case "B":
                case "b":
                    _boardGameLogic.DisplayGameById();
                    break;
                case "C":
                case "c":
                    _boardGameLogic.DisplayAllGames();
                    break;
                case "D":
                case "d":
                    _boardGameLogic.RemoveGame();
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
               