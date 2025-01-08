
using ClaimTheSquare.Model;
using Dapper;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
var connStr = "Data Source=(localdb)\\local;Initial Catalog=ClaimTheSquare;Integrated Security=True";
app.MapGet("/textObjects", async () =>
{
    var sql = "SELECT * FROM TextObject";
    var conn = new SqlConnection(connStr);
    var textObjects = await conn.QueryAsync<TextObjects>(sql);
    return textObjects;
});

app.MapPost("/textObjects", async (TextObjects newTextObject) =>
{
    var sql = "INSERT INTO TextObject VALUES (@Index, @Text, @ForeColor, @BackColor)";
    var conn = new SqlConnection(connStr);
    var rowsAffected = await conn.ExecuteAsync(sql, newTextObject);
    return rowsAffected;
});
app.MapPut("/textObjects/{index:int}", async (TextObjects updatedTextObject) =>
{
    var sql = "UPDATE TextObject SET Text = @Text, ForeColor = @ForeColor, BackColor = @BackColor WHERE [Index] = @Index";
    var conn = new SqlConnection(connStr);
    var rowsAffected = await conn.ExecuteAsync(sql, updatedTextObject);
    return rowsAffected;
});
app.Run();