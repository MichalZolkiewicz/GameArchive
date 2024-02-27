namespace GameArchive.ApplicationServices.Logic
{
    public interface IEventLoggerLogic
    {
        void GameRepositoryOnItemAdded<T>(object? sender, T item);

        void GameRepositoryOnItemRemoved<T>(object? sender, T item);
    }
}