using Algebra.HelloWorld.WebApp.Data.Abstractions;
using Algebra.HelloWorld.WebApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Algebra.HelloWorld.WebApp.Data.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity
{
    private readonly AppDbContext _context;

    public GenericRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<T>> Get()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T> Get(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task Put(int id, T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task<T> Post(T entity)
    {
        _context.Set<T>().Add(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task Delete(int id)
    {
        var entity = await _context.Set<T>().FindAsync(id);
        if (entity != null)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

    public bool Exists(int id)
    {
        return _context.Set<T>().Any(e => e.Id == id);
    }
}
