using MotoApp.Data.Entities;

namespace MotoApp.Data.Repositories;

public interface IReadRepository<out T> where T : class, IEntiti
{
    IEnumerable<T> GetAll();
    T GetById(int id);
}
