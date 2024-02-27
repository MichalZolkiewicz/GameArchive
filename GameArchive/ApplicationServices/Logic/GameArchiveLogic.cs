using GameArchive.ApplicationServices.DataProvider;
using GameArchive.ApplicationServices.DataProvider.Extension;
using GameArchive.Data.Entities;

namespace GameArchive.ApplicationServices.Logic;

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
    public void ChooseRepository(string gameChoice)
    {
        if (gameChoice == "1")
        {
            var actionChoice = ChooseAction();
            switch (actionChoice)
            {
                case "A":
                    _videoGameLogic.AddGame();
                    break;
                case "B":
                    _videoGameLogic.DisplayGameById();
                    break;
                case "C":
                    _videoGameLogic.DisplayAllGames();
                    break;
                case "D":
                    _videoGameLogic.DisplayAllGames();
                    Console.WriteLine("Please choose ID number you would like to update.");
                    var id = Console.ReadLine();
                    _videoGameLogic.UpdateGame(id);
                    break;
                case "E":
                    _videoGameLogic.RemoveGame();
                    break;
                case "F":
                    Console.WriteLine(_videoGameProvider.GetTheEarliestProducedGame());
                    break;
                case "G":
                    var producers = _videoGameProvider.GetUniqueGameProducer();
                    GameProviderExtension.DisplayUniqueGameProducers(producers);
                    break;
                case "H":
                    var orderedGames = _videoGameProvider.OrderByName();
                    GameProviderExtension.DisplayGamesOrderedByName(orderedGames);
                    break;
                case "I":
                    Console.WriteLine("Please insert category");
                    string category = Console.ReadLine();
                    var games = _videoGameProvider.WhereCategoryIs(category);
                    GameProviderExtension.DisplayGamesWhereCategoryIs(games);
                    break;
                default:
                    throw new Exception("Wrong letter!");
            }
        }
        else if (gameChoice == "2")
        {
            var actionChoice = ChooseAction();
            switch (actionChoice)
            {
                case "A":
                    _boardGameLogic.AddGame();
                    break;
                case "B":
                    _boardGameLogic.DisplayGameById();
                    break;
                case "C":
                    _boardGameLogic.DisplayAllGames();
                    break;
                case "D":
                    _boardGameLogic.DisplayAllGames();
                    Console.WriteLine("Please choose ID number you would like to update.");
                    var id = Console.ReadLine();
                    _boardGameLogic.UpdateGame(id);
                    break;
                case "E":
                    _boardGameLogic.RemoveGame();
                    break;
                case "F":
                    Console.WriteLine(_boardGameProvider.GetTheEarliestProducedGame());
                    break;
                case "G":
                    var producers = _boardGameProvider.GetUniqueGameProducer();
                    GameProviderExtension.DisplayUniqueGameProducers(producers);
                    break;
                case "H":
                    var orderedGames = _boardGameProvider.OrderByName();
                    GameProviderExtension.DisplayGamesOrderedByName(orderedGames);
                    break;
                case "I":
                    Console.WriteLine("Please insert category");
                    string category = Console.ReadLine();
                    var games = _boardGameProvider.WhereCategoryIs(category);
                    GameProviderExtension.DisplayGamesWhereCategoryIs(games);
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

    public string ChooseAction()
    {
        Console.WriteLine("\nChoose action:\nA => Add game\nB => Display game\nC => Display all games\nD => Update game\nE => Remove Game" +
                              "\nF => Show earliest produced game\nG => Show unique producers\nH => Order by name\nI => Filter by category name");
        Console.WriteLine();
        var actionChoice = Console.ReadLine().ToUpper();
        return actionChoice;
    }
}
