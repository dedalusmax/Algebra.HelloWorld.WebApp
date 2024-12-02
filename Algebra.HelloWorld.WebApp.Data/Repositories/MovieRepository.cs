using Algebra.HelloWorld.WebApp.Data.Abstractions;
using Algebra.HelloWorld.WebApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Algebra.HelloWorld.WebApp.Data.Repositories;

public class MovieRepository : IGenericRepository<Movie>
{
    private readonly AppDbContext _context;

    public MovieRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Movie>> Get()
    {
        return await _context.Movies.ToListAsync();
    }

    public async Task<Movie> Get(int id)
    {
        return await _context.Movies.FindAsync(id);
    }

    public async Task Put(int id, Movie movie)
    {
        _context.Entry(movie).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task<Movie> Post(Movie movie)
    {
        _context.Movies.Add(movie);
        await _context.SaveChangesAsync();

        return movie;
    }

    public async Task Delete(int id)
    {
        var movie = await _context.Movies.FindAsync(id);
        if (movie != null)
        {
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
        }
    }

    public bool Exists(int id)
    {
        return _context.Movies.Any(e => e.Id == id);
    }
}
