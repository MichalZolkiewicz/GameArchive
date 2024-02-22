using GameArchive.Data.DataProvider;
using GameArchive.Data.Entities;
using GameArchive.Logic;

namespace GameArchive.UserCommuniation;

public class UserCommunication : IUserCommunication
{
    private readonly IGameArchiveLogic _gameArchiveLogic;

    public UserCommunication(IGameArchiveLogic gameArchiveLogic)
    {
        _gameArchiveLogic = gameArchiveLogic;
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

            try
            {
                _gameArchiveLogic.ChooseActionAndRepository(input);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception catched: {e.Message}");
            }
        }
    }
}
