using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using WebApplication5.Data;
using WebApplication5.Repositories.Abstract;
using WebApplication5.Repositories.Concrete;
using WebApplication5.Services;
using WebApplication5.Services.Abstract;
using WebApplication5.Services.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHostedService<MyBackgroundService>();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IOmdbService, OMDBService>();


builder.Services.AddSingleton<HttpClient>();



var conn = builder.Configuration.GetConnectionString("myconn");
builder.Services.AddDbContext<MovieDBContext>(opt =>
{
    opt.UseSqlServer(conn);
});



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
