using Algebra.HelloWorld.WebApp.Data;
using Algebra.HelloWorld.WebApp.Data.Abstractions;
using Algebra.HelloWorld.WebApp.Data.Entities;
using Algebra.HelloWorld.WebApp.Data.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connStr = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connStr));

//builder.Services.AddScoped<IMovieRepository, MovieRepository>();
//builder.Services.AddScoped<IGenericRepository<Movie>, MovieRepository>();
builder.Services.AddScoped<IGenericRepository<Movie>, GenericRepository<Movie>>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
