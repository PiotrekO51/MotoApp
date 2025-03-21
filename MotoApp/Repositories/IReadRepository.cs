using MotoApp.Entities;
namespace MotoApp.Repositories;

public interface IReadRepository<out T> where T : class, IEntiti
{
    IEnumerable<T> GetAll();
    T GetById(int id);
}
