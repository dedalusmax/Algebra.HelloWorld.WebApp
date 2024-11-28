using Algebra.HelloWorld.WebApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Algebra.HelloWorld.WebApp.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    public DbSet<Movie> Movies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MoviesDB;Trusted_Connection=true;");

        base.OnConfiguring(optionsBuilder);
    }
}
