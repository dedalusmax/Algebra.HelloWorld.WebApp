using Algebra.HelloWorld.WebApp.API.Controllers;
using Algebra.HelloWorld.WebApp.Data;
using Algebra.HelloWorld.WebApp.Data.Repositories;

namespace Algebra.HelloWorld.WebApp.UnitTests;

public class TestFixture : IDisposable
{
    internal MoviesController Controller { get; init; }

    public TestFixture()
    {
        var context = new AppDbContext();
        var repository = new MovieRepository(context);
        Controller = new MoviesController(repository);
    }

    public void Dispose()
    {
        // TODO: clean up code
    }
}
