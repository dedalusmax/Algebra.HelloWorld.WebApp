using Algebra.HelloWorld.WebApp.Data.Abstractions;
using Algebra.HelloWorld.WebApp.Data.Entities;

namespace Algebra.HelloWorld.WebApp.Data.Repositories;

public class MovieRepository(AppDbContext context) : GenericRepository<Movie>(context), IMovieRepository // IGenericRepository<Movie>
{
    public async Task<List<Movie>> GetMoviesFiltered(string name, bool ascendingOrder, int page, int recordsPerPage)
    {
        var query = context.Movies as IQueryable<Movie>;

        if (!string.IsNullOrEmpty(name))
        {
            query = query.Where(x => x.Name.StartsWith(name));  
        }

        query = ascendingOrder ? query.OrderBy(x => x.Name) : query.OrderByDescending(x => x.Name);

        query = query.Skip(page - 1).Take(recordsPerPage);

        return query.ToList();
    }
}
