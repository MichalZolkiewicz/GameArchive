using GameArchive.Data;
using GameArchive.Entities;
using GameArchive.Logic;
using GameArchive.Repositories;
using GameArchive.Repositories.Extensions;

//var videoGameRepository = new SqlRepository<VideoGame>(new GameArchiveDbContext(), GameAdded);
//videoGameRepository.ItemAdded += VideoGameRepositoryOnItemAdded;

var boardGameRepository = new SqlRepository<BoardGame>(new GameArchiveDbContext());

var videoGameRepository2 = new SqlRepository<VideoGame>(new GameArchiveDbContext(), GameAdded);

var archiveLogic = new GameArchiveLogic();

void VideoGameRepositoryOnItemAdded(object? sender, VideoGame e)
{
    Console.WriteLine($"Video Game added => {e.Name} from {sender?.GetType().Name}");
}

//AddVideoGame(videoGameRepository2);
//WriteAllToConsole(videoGameRepository2);

//SqlRepository<T> chooseRepo<T>(string input)
//    where T : class, IEntity, new()
//{
//    switch(input)
//    {
//        case "A":
//        case "a":
//            return videoGameRepository;
//            break;
//        case "B":
//        case "b":
//            return boardGameRepository;
//        default:
//            throw new Exception("Wrong letter!");
//    }
//}

static void GameAdded(VideoGame item)
{
    Console.WriteLine($"\n{item.Name} added");
}

static void WriteAllToConsole(IReadRepository<IEntity> repository)
{
    var items = repository.GetAll();
    foreach (var item in items)
    {
        Console.WriteLine();
        Console.WriteLine(item);
    }
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
