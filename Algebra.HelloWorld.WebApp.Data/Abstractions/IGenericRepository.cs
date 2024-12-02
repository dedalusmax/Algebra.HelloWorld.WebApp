namespace Algebra.HelloWorld.WebApp.Data.Abstractions;

public interface IGenericRepository<T> where T : class
{
    Task<List<T>> Get();

    Task<T> Get(int id);

    Task Put(int id, T entity);

    Task<T> Post(T entity);

    Task Delete(int id);

    bool Exists(int id);
}
