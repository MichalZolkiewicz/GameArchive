namespace GameArchive.Logic;

public class EventLoggerLogic
{
    private const string eventLoggerFile = "eventLogger.txt";

    public static void GameRepositoryOnItemAdded<T>(object? sender, T item)
    {
        DateTime localDate = DateTime.Now;
        string eventLine = localDate.ToString() + "-" + item.GetType().Name + " added";
        using (var writer = File.AppendText(eventLoggerFile))
        {
            writer.WriteLine(eventLine);
        }
    }

    public static void GameRepositoryOnItemRemoved<T>(object? sender, T item)
    {
        DateTime localDate = DateTime.Now;
        string eventLine = localDate.ToString() + "-" + item.GetType().Name + " removed";
        using (var writer = File.AppendText(eventLoggerFile))
        {
            writer.WriteLine(eventLine);
        }
    }

}
