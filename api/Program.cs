using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using WeatherApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddCors();

string connectionString = "Server=localhost,1433;Database=WeatherApp;User Id=sa;Password=//PASSWORD;Encrypt=False;";

builder.Services.AddScoped<MsSql>(provider =>
{
    var connection = new SqlConnection(connectionString);
    return new MsSql(connection);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapPost("/api", async (MsSql msSql) =>
{
    return await msSql.ReadWeatherData();
});

app.MapGet("/api", async ([FromServices]MsSql msSql) =>
{
    return await msSql.ReadWeatherData();
});

app.UseCors(builder =>
{
    builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
});

app.UseHttpsRedirection();

app.Run();
