using Microsoft.EntityFrameworkCore;
using CentroMedicoWebAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Se declara contexto de la base de datos
builder.Services.AddDbContext<CentroMedicoContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("sql"));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("TodasLasConexiones", app =>
    {
        app.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("TodasLasConexiones");

app.UseAuthorization();

app.MapControllers();

app.Run();
