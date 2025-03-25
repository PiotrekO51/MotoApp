using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using MotoApp.Data;
using MotoApp.Data.Entities;

namespace MotoApp.Data.Repositories;

public class SqlRepository<T> : IRepository<T> where T : class, IEntiti, new()
{
    public event EventHandler<T>? ItemAdded;
    private readonly DbContext _dbContext;
    private DbSet<T> _dbSet;

    public SqlRepository(DbContext DbContext)
    {
        _dbContext = DbContext;
        _dbSet = _dbContext.Set<T>();

    }

    public void Add(T item)
    {
        item.Id = _dbSet.Count() + 1;
        _dbSet.Add(item);
        ItemAdded?.Invoke(this, item);
    }

    public IEnumerable<T> GetAll()
    {
        _dbSet.ToList();
        return _dbSet;
    }

    public T GetById(int id)
    {
        return _dbSet.Single(item => item.Id == id);
    }

    public void Remove(T item)
    {
        _dbSet.Remove(item);
    }

    public void Save()
    {
        _dbContext.SaveChanges();
    }
    public void InsertItem(int index, T item)
    {
        throw new NotImplementedException();
    }
}
