using GameArchive.Data;
using GameArchive.Entities;
using GameArchive.Repositories;
using GameArchive.Repositories.Extensions;

namespace GameArchive.Logic;

public class GameArchiveLogic
{
    static VideoGameLogic videoGameLogic = new VideoGameLogic();
    static BoardGameLogic boardGameLogic = new BoardGameLogic();
    SqlRepository<VideoGame> videoGameRepository = new SqlRepository<VideoGame>(new GameArchiveDbContext());

    public void ChooseActionAndRepository(string typeInput)
    {
        if (typeInput == "1")
        {
            Console.WriteLine("Welcome to game archive application!\n\nPlease tell me what you want to do?");
            Console.WriteLine("\nChoose action:\nA => Add game\nB => Display game\nC => Display all games\nD => Remove Game\nTo quit press Q");
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
                default:
                    throw new Exception("Wrong letter!");
            }
        }
        else if(typeInput == "2")
        {
            Console.WriteLine("Welcome to game archive application!\n\nPlease tell me what you want to do?");
            Console.WriteLine("\nChoose action:\nA => Add game\nB => Display game\nC => Display all games\nD => Remove Game\nTo quit press Q");
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
