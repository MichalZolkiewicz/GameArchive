using GameArchive.Data.DataProvider;
using GameArchive.Data.Entities;
using GameArchive.Logic;

namespace GameArchive.UserCommuniation;

public class UserCommunication : IUserCommunication
{
    private readonly IGameProvider<VideoGame> _videoGameProvider;
    private readonly IGameProvider<BoardGame> _boardGameProvider;

    public UserCommunication(IGameProvider<VideoGame> videoGameProvider, IGameProvider<BoardGame> boardGameProvider)
    {
        _videoGameProvider = videoGameProvider;
        _boardGameProvider = boardGameProvider; 
    }
    public void RunApp()
    {
        while (true)
        {
            Console.WriteLine("Welcome to game archive application!");
            Console.WriteLine("\nChoose game type:\n1 => Video Game, 2 => Board Game\nTo quit press Q");
            Console.WriteLine();
            var input = Console.ReadLine();

            if (input == "q" || input == "Q")
            {
                break;
            }

            GameArchiveLogic gameLogic = new GameArchiveLogic(_videoGameProvider, _boardGameProvider);

            try
            {
                gameLogic.ChooseActionAndRepository(input);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception catched: {e.Message}");
            }
        }
    }
}
