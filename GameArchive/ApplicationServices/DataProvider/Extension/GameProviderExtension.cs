namespace GameArchive.ApplicationServices.DataProvider.Extension;

public static class GameProviderExtension
{
    public static void DisplayGamesWhereCategoryIs<T>(List<T> games)
    {
        foreach (var game in games)
        {
            Console.WriteLine(game);
        }
    }

    public static void DisplayUniqueGameProducers(List<string> producers)
    {
        foreach (var producer in producers)
        {
            Console.WriteLine(producer);
        }
    }

    public static void DisplayGamesOrderedByName<T>(List<T> games)
    {
        foreach (var game in games)
        {
            Console.WriteLine($"\n{game}");
        }
    }
}
