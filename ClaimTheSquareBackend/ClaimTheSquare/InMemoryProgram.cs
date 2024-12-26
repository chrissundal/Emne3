using ClaimTheSquare.Model;

namespace ClaimTheSquare;

public class InMemoryProgram
{
    public static void Run(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        app.UseStaticFiles();
        var datamanager = new DataManager();

        app.MapGet("/textObjects", () => datamanager.GetTextObjects());
        app.MapPost("/textObjects", (TextObjects textObjects) => { datamanager.AddNewObjects(textObjects); });
        app.Run();
    }
}