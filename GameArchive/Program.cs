using GameArchive.Logic;

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
