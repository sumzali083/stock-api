var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/stocks/{symbol}", (string symbol) =>
{
    var path = $"stocks/{symbol}.json";

    if (!File.Exists(path))
        return Results.NotFound("Stock not found");

    var json = File.ReadAllText(path);

    return Results.Content(json, "application/json");
});

app.MapGet("/stocks/{symbol}/price", (string symbol) =>
{
    var path = $"stocks/{symbol}.json";

    if (!File.Exists(path))
        return Results.NotFound("Stock not found");

    var json = File.ReadAllText(path);

    // For now just return the whole file again
    return Results.Content(json, "application/json");
});

app.Run();