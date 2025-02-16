using Backend.Data;
using Microsoft.EntityFrameworkCore;
using Backend.Services;
using DotNetEnv;

var builder = WebApplication.CreateBuilder(args);

Env.Load();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddHttpClient<WeatherServices>();

builder.Services.AddDbContext<WeatherDbContext>(options =>
        options.UseSqlServer(Environment.GetEnvironmentVariable("MS_SQL")));

builder.Services.AddControllers();

var app = builder.Build();

app.UseCors(builder =>
		builder.AllowAnyOrigin()
		.AllowAnyMethod()
		.AllowAnyHeader());

app.UseRouting();
app.UseAuthorization();
app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();



app.Run();

