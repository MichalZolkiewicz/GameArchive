namespace GameArchive.Data.DataProvider;

public interface IGameProvider<T> 
    where T : class
{
    List<string> GetUniqueGameProducer();
    int GetTheEarliestProducedGame();
    List<T> OrderByName();
    List<T> WhereCategoryIs(string category);
}
