using Algebra.HelloWorld.WebApp.Data.Entities;

namespace Algebra.HelloWorld.WebApp.Data.Abstractions;

public interface IMovieRepository
{
    Task<List<Movie>> GetMovies();

    Task<Movie> GetMovie(int id);

    Task PutMovie(int id, Movie movie);

    Task<Movie> PostMovie(Movie movie);

    Task DeleteMovie(int id);

    bool MovieExists(int id);
}
