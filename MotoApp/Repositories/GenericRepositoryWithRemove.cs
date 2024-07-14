using MotoApp.Entities;
using MotoApp.Repositories;
using MotoApp.Entities;
namespace MotoApp.Repositories;

public class GenericRepositoryWithRemove<T> : ListRepository<T> where T : class, IEntity, new()
{
    public void Remove(T item)
    {
        _items.Remove(item);
    }
}
