using lampadaire.Interface;
using lampadaire.Models;
using lampadaire.MongoDBConnection;
using lampadaire.Service;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(); 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ILampadaireService, LampadaireService>();
builder.Services.AddScoped<ICapteurService, CapteurService>();

builder.Services.Configure<MongoDbSetting>(
    builder.Configuration.GetSection("MongoDbSettings"));

builder.Services.AddSingleton<IMongoClient>(sp =>
{
    var settings = sp.GetRequiredService<IOptions<MongoDbSetting>>().Value;
    return new MongoClient(settings.ConnectionString);
});

builder.Services.AddSingleton<IMongoDatabase>(sp =>
{
    var settings = sp.GetRequiredService<IOptions<MongoDbSetting>>().Value;
    var client = sp.GetRequiredService<IMongoClient>();
    return client.GetDatabase(settings.DatabaseName);
});

builder.Services.AddScoped(serviceProvider =>
{
    var settings = serviceProvider.GetRequiredService<IOptions<MongoDbSetting>>().Value;
    var database = serviceProvider.GetRequiredService<IMongoDatabase>();

    return new
    {
        Lampadaires = database.GetCollection<Lampadaire>(settings.LampadaireCollectionName),
        Capteurs = database.GetCollection<Capteur>(settings.CapteurCollectionName),
        Horaires = database.GetCollection<Horaire>(settings.HoraireCollectionName),
        Utilisateurs = database.GetCollection<Utilisateur>(settings.UtilisateurCollectionName)
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers(); 

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
            new WeatherForecast
            (
                DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                Random.Shared.Next(-20, 55),
                summaries[Random.Shared.Next(summaries.Length)]
            ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
