using System.Text.Json;
using NettbutikkAPI;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseHttpsRedirection();
app.UseStaticFiles();
var datamanager = new DataManager();
List<Product> Allproducts;
List<Person> Users;
if (File.Exists("products.json"))
{
    var json = File.ReadAllText("products.json");
    Allproducts = JsonSerializer.Deserialize<List<Product>>(json);
}
else
{
    Allproducts = datamanager.GetProducts();
}

if (File.Exists("users.json"))
{
    var json = File.ReadAllText("users.json"); 
    Users = JsonSerializer.Deserialize<List<Person>>(json);
}
else
{
    Users = datamanager.GetUsers();
}
app.MapGet("/products", () => Allproducts);
app.MapGet("/users", () => Users);
app.MapGet("/users/{id:int}", (int id) =>
{
    var user = Users.FirstOrDefault(u => u.Id == id); 
    return user != null ? Results.Ok(user) : Results.NotFound("User not found");
});
app.MapPost("/products", (Product newProduct) =>
{
    Allproducts.Add(newProduct);
    var json = JsonSerializer.Serialize(Allproducts);
    File.WriteAllText("products.json", json);
});
app.MapPost("/users", (Person newUser) => 
{ 
    Users.Add(newUser); 
    var json = JsonSerializer.Serialize(Users); 
    File.WriteAllText("users.json", json); 
});    
app.MapPut("/products/{id:int}", (int id, Product updatedProduct) =>
{
    var product = Allproducts.FirstOrDefault(p => p.Id == id);
    if (product != null)
    {
        product.SetStock(updatedProduct.Stock);
        var json = JsonSerializer.Serialize(Allproducts);
        File.WriteAllText("products.json", json);
        return Results.Ok(updatedProduct);
    }
    else
    {
        return Results.NotFound("Product not found");
    }
});

app.MapPut("/users/{id:int}/checkout", (int id) =>
{
    var user = Users.FirstOrDefault(u => u.Id == id);
    if (user != null)
    {
        user.Checkout(); 
        var json = JsonSerializer.Serialize(Users); 
        File.WriteAllText("users.json", json); 
        return Results.Ok(user);
    }
    else
    {
        return Results.NotFound("User not found");
    }
});
app.MapPut("/users/{id:int}", (int id, Person updatedUser) =>
{
    var userIndex = Users.FindIndex(u => u.Id == id);
    if (userIndex >= 0)
    {
        Users[userIndex] = updatedUser;
        var json = JsonSerializer.Serialize(Users);
        File.WriteAllText("users.json", json);
        return Results.Ok(updatedUser);
    }
    else
    {
        return Results.NotFound("User not found");
    }
});

app.Run();

