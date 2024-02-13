using GameArchive.Entities;

namespace GameArchive.Repositories.Extensions;

public static class RepositoryExtensions
{
    public static void RemoveGame<T>(this IRepository<T> repository, T item)
    where T : class, IEntity
    {
        repository.Remove(item);
        repository.Save();
    }

   public static void AddGame<T>(this IRepository<T> repository, T item)
   where T : class, IEntity
    {
        repository.Add(item);
        repository.Save();
    }

    
    public static void FindGamebyId<T>(this IRepository<T> repository, T item)
    where T : class, IEntity
    {
        repository.GetById(item.Id);
        repository.Save();
    }

    public static void GetAllGames<T>(this IRepository<T> repository)
    where T : class, IEntity
    {
        repository.GetAll();
    }
}
