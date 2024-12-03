using Algebra.HelloWorld.WebApp.API.Controllers;
using Algebra.HelloWorld.WebApp.Data;
using Algebra.HelloWorld.WebApp.Data.Entities;
using Algebra.HelloWorld.WebApp.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Algebra.HelloWorld.WebApp.UnitTests
{
    public class MoviesControllerTests
    {
        [Fact]
        public async void TestMoviesController_GetMovies_Ok()
        {
            // Arrange
            var context = new AppDbContext();
            var repository = new MovieRepository(context);
            var controller = new MoviesController(repository);

            // Act 
            var result = await controller.GetMovies();

            // Assert
            Assert.NotNull(result);
            //Assert.IsType<OkObjectResult>(result);
            Assert.IsAssignableFrom<ActionResult<IEnumerable<Movie>>>(result);
            Assert.NotNull(result.Value);
            Assert.IsAssignableFrom<IEnumerable<Movie>>(result.Value);
            Assert.NotEmpty(result.Value);
            Assert.Equal(9, result.Value.Count());  
        }
    }
}