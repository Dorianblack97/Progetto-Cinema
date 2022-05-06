using Microsoft.EntityFrameworkCore;
using ProgettoCinema.API.Data;
using ProgettoCinema.API.Repository;
using ProgettoCinema.Domain;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<GenericRepository<Cinema>>();
builder.Services.AddScoped<GenericRepository<Film>>();
builder.Services.AddScoped<GenericRepository<Biglietto>>();
builder.Services.AddScoped<GenericRepository<Spettatore>>();
builder.Services.AddScoped<GenericRepository<SalaCinematografica>>();
builder.Services.AddScoped<GenericRepository<GenereFilm>>();
builder.Services.AddDbContext<CinemaDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultDatabase")));


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
