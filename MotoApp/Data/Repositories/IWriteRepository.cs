using MotoApp.Data.Entities;

namespace MotoApp.Data.Repositories;

public interface IWriteRepository<in T> where T : class, IEntiti
{
    void Add(T item);
    void Remove(T item);
    void Save();
    public void InsertItem(int index, T item);
}
