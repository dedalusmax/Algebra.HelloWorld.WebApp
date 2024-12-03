using Algebra.HelloWorld.WebApp.Data.Entities;

namespace Algebra.HelloWorld.WebApp.Data.Abstractions;

public interface IMovieRepository : IGenericRepository<Movie>
{
    Task<List<Movie>> GetMoviesFiltered(string name, bool ascendingOrder, int page, int recordsPerPage);
}
