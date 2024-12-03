using Algebra.HelloWorld.WebApp.Data.Abstractions;
using Algebra.HelloWorld.WebApp.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Algebra.HelloWorld.WebApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController(IMovieRepository repository) : ControllerBase
    {
        // GET: api/Movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        {
            var result = await repository.Get();
            return (result.Count == 0 ? NoContent() : result);
        }

        [HttpGet("{name}/{ascendingOrder}/{recordsPerPage}")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMoviesFiltered(string name, bool ascendingOrder, int page, int recordsPerPage)
        {
            var result = await repository.GetMoviesFiltered(name, ascendingOrder, page, recordsPerPage);
            return (result.Count == 0 ? NoContent() : result);
        }

        // GET: api/Movies/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            var movie = await repository.Get(id);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        // PUT: api/Movies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutMovie(int id, Movie movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }

            try
            {
                await repository.Put(id, movie);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!repository.Exists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Movies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
            movie = await repository.Post(movie);

            return CreatedAtAction("GetMovie", new { id = movie.Id }, movie);
        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            if (!repository.Exists(id))
            {
                return NotFound();
            }

            await repository.Delete(id);

            return NoContent();
        }
    }
}
