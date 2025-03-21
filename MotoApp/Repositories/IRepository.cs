using MotoApp.Entities;
namespace MotoApp.Repositories;
public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T>   
    where T:class,IEntiti, new()
{ 
    public event EventHandler<T>? ItemAdded;
}
