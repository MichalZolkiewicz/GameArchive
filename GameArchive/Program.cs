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
    Console.WriteLine("Welcome to game archive application!\n\nPlease tell me what you want to do?");
    Console.WriteLine("\nChoose action:\n1 => Add game\n2 => Display game\n3 => Display all games\n4 => Remove Game\nTo quit press Q");
    Console.WriteLine();
    var input = Console.ReadLine();

    if (input == "q" || input == "Q")
    {
        break;
    }

    
    Console.WriteLine("\nChoose game type:\nA => Video Game, B => Board Game\nTo quit press Q");
    Console.WriteLine();
    var input2 = Console.ReadLine();

    if (input2 == "q" || input2 == "Q")
    {
        break;
    }

    try
    {
        Console.WriteLine("Insert name");
        var gameName = Console.ReadLine();
        Console.WriteLine("Insert category");
        var gameCategory = Console.ReadLine();
        Console.WriteLine("Insert publication year");
        var gamePublicationYear = archiveLogic.ConvertStringToInteger(Console.ReadLine());
        Console.WriteLine("Insert producer");
        var gameProducer = Console.ReadLine();
        Console.WriteLine("Insert if there is online option");
        var gameOnlineOption = archiveLogic.ConvertStringToBoolean(Console.ReadLine());


        VideoGame videoGame = new VideoGame { Name = gameName, Category = gameCategory, PublicationYear = gamePublicationYear, Producer = gameProducer, OnlineOption = gameOnlineOption };

        videoGameRepository2.AddGame(videoGame);
    }
    catch (Exception e)
    {
        Console.WriteLine($"Exception catched: {e.Message}");
    }    
}
