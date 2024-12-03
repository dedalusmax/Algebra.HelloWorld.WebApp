using Algebra.HelloWorld.WebApp.API.Controllers;
using Algebra.HelloWorld.WebApp.Data;
using Algebra.HelloWorld.WebApp.Data.Entities;
using Algebra.HelloWorld.WebApp.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Algebra.HelloWorld.WebApp.UnitTests
{
    public class MoviesControllerTests
    {
        private readonly MoviesController _controller;

        public MoviesControllerTests()
        {
            // Arrange

            var context = new AppDbContext();
            var repository = new MovieRepository(context);
            _controller = new MoviesController(repository);
        }

        [Fact]
        public async void TestMoviesController_GetMovies_Ok()
        {
            // Arrange

            // Act 
            var result = await _controller.GetMovies();

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<ActionResult<IEnumerable<Movie>>>(result);
            Assert.NotNull(result.Value);
            Assert.IsAssignableFrom<IEnumerable<Movie>>(result.Value);
            Assert.NotEmpty(result.Value);
            Assert.Equal(9, result.Value.Count());  
        }

        [Theory]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        public async void TestMoviesController_GetMovie_Ok(int id)
        {
            // Arrange

            // Act 
            var response = await _controller.GetMovie(id);

            // Assert
            Assert.NotNull(response);
            Assert.IsAssignableFrom<ActionResult<Movie>>(response);
            Assert.IsType<OkObjectResult>(response.Result);
            var result = response.Result as OkObjectResult;
            Assert.NotNull(result);
            Assert.IsType<Movie>(result.Value);
            Assert.NotNull(result.Value);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(200)]
        public async void TestMoviesController_GetMovie_NotFound(int id)
        {
            // Arrange

            // Act 
            var response = await _controller.GetMovie(id);

            // Assert
            Assert.NotNull(response);
            Assert.IsAssignableFrom<ActionResult<Movie>>(response);
            Assert.IsType<NotFoundResult>(response.Result);
            var result = response.Result as NotFoundResult;
            Assert.NotNull(result);
        }

        // TODO: PutMovie, PostMovie, DeleteMovie
    }
}