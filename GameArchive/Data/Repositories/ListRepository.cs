using GameArchive.Data.Entities;

namespace GameArchive.Data.Repositories;

public class ListRepository<T> : IRepository<T>
    where T : class, IEntity, new()

{
    protected readonly List<T> _items = new();

    public event EventHandler<T>? ItemAdded;
    public event EventHandler<T>? ItemRemoved;
    public IEnumerable<T> GetAll()
    {
        return _items.ToList();
    }

    public T GetById(int id)
    {
        return _items.Single(item => item.Id == id);
    }

    public void Add(T item)
    {
        item.Id = _items.Count + 1;
        _items.Add(item);
    }

    public void Save()
    {

    }

    public void Remove(T item)
    {
        _items.Remove(item);
    }
}
