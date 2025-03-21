using MotoApp.Entities;

namespace MotoApp.Repositories;

public class ListRepository<T> : IRepository<T> where T : class, IEntiti, new()
{
    private readonly List<T> _items;
    public event EventHandler<T>? ItemAdded;

    public ListRepository()
    {
        _items = new List<T>();
    }

    public void Add(T item)
    {
        item.Id = _items.Count + 1;
        _items.Add(item);
        ItemAdded?.Invoke (this, item);
    }
    public IEnumerable<T> GetAll() => _items.ToList();

    public T GetById(int id) => _items.Single(item => item.Id == id);

    public void Remove(T item)
    {
        _items.Remove(item);
    }

    public void Save()
    {
        //_items.SaveChanges();
    }
    public void InsertItem(int index, T item)
    {
        _items.Insert(index, item);
    }
}
