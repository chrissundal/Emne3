using TestAPI2;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseHttpsRedirection();
var start = new Start();
app.MapGet("/people", () => start.GetPeople());

app.Run();
