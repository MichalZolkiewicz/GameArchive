using GameArchive.Data;
using GameArchive.Entities;
using GameArchive.Logic;
using GameArchive.Repositories;

var boardGameRepository = new SqlRepository<BoardGame>(new GameArchiveDbContext());
var videoGameRepository2 = new SqlRepository<VideoGame>(new GameArchiveDbContext(), GameAdded);
videoGameRepository2.ItemAdded += VideoGameRepositoryOnItemAdded;


void VideoGameRepositoryOnItemAdded(object? sender, VideoGame e)
{
    Console.WriteLine($"Video Game added => {e.Name} from {sender?.GetType().Name}");
}

static void GameAdded(VideoGame item)
{
    Console.WriteLine($"\n{item.Name} added");
}

while (true)
{
    Console.WriteLine("\nChoose game type:\n1 => Video Game, 2 => Board Game\nTo quit press Q");
    Console.WriteLine();
    var input = Console.ReadLine();

    if (input == "q" || input == "Q")
    {
        break;
    }

    GameArchiveLogic gameLogic = new GameArchiveLogic();

    try
    {
        gameLogic.ChooseActionAndRepository(input);
    }
    catch (Exception e)
    {
        Console.WriteLine($"Exception catched: {e.Message}");
    }    
}
