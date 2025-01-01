using System.Text.Json;
using ClaimTheSquare.Model;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

var dataManager = new DataManager();
List<TextObjects> textObjects;

if (File.Exists("textobjects.json"))
{
    var json = File.ReadAllText("textobjects.json");
    textObjects = JsonSerializer.Deserialize<List<TextObjects>>(json);
}
else
{
    textObjects = dataManager.GetTextObjects();
}

app.MapGet("/textObjects", () => textObjects);

app.MapPost("/textObjects", (TextObjects newTextObject) =>
{
    textObjects.Add(newTextObject);
    var json = JsonSerializer.Serialize(textObjects);
    File.WriteAllText("textobjects.json", json);
    return Results.Ok(newTextObject);
});

app.Run();