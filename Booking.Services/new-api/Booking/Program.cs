using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
public class Startup
{
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        // Database connection with PostgreSQL
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(_configuration.GetConnectionString("DefaultConnection")));

        // Other configurations
        services.AddControllers();
    }

    builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/slots", () =>
{
    // controller to get all slots
    // var forecast =  Enumerable.Range(1, 5).Select(index =>
    //     new WeatherForecast
    //     (
    //         DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
    //         Random.Shared.Next(-20, 55),
    //         summaries[Random.Shared.Next(summaries.Length)]
    //     ))
    //     .ToArray();
    // return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();


    // Rest of the code
}
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
