using System.Text.Json;
using NettbutikkAPI;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseHttpsRedirection();
app.UseStaticFiles();
var datamanager = new DataManager();
List<Product> allproducts;
List<Person> users;
List<Order> orders;
if (File.Exists("products.json"))
{
    var json = File.ReadAllText("products.json");
    allproducts = JsonSerializer.Deserialize<List<Product>>(json);
}
else
{
    allproducts = datamanager.GetProducts();
}

if (File.Exists("users.json"))
{
    var json = File.ReadAllText("users.json");
    users = JsonSerializer.Deserialize<List<Person>>(json);
}
else
{
    users = datamanager.GetUsers();
}
if (File.Exists("orders.json"))
{
    var json = File.ReadAllText("orders.json");
    orders = JsonSerializer.Deserialize<List<Order>>(json) ?? new List<Order>();
}
else
{
    orders = datamanager.GetOrders();
}
app.MapGet("/orders", () => orders);
app.MapGet("/products", () => allproducts);
app.MapGet("/users", () => users);
app.MapGet("/check-username/{username}", (string username) =>
{
    var userExists = users.Any(u => u.UserName == username);
    return Results.Ok(userExists);
});
app.MapGet("/userslength", () => users.Count);
app.MapGet("/users/{id:int}", (int id) =>
{
    var user = users.FirstOrDefault(u => u.Id == id);
    if (user != null)
    {
        return Results.Ok(user);
    }
    else
    {
        return Results.NotFound("User not found");
    }
});
app.MapPost("/login", (LoginRequest loginRequest) =>
{
    Console.WriteLine($"Received login attempt with Username: {loginRequest.UserName}, Password: {loginRequest.PassWord}");
    var user = users.FirstOrDefault(u => u.UserName == loginRequest.UserName && u.PassWord == loginRequest.PassWord);
    if (user != null)
    {
        return Results.Ok(user);
    }
    else
    {
        return Results.Unauthorized();
    }
});
app.MapPost("/products", (Product newProduct) =>
{
    newProduct.SetId(allproducts.Count);
    allproducts.Add(newProduct);
    var json = JsonSerializer.Serialize(allproducts);
    File.WriteAllText("products.json", json);
});
app.MapPost("/users", (Person newUser) =>
{
    users.Add(newUser);
    var json = JsonSerializer.Serialize(users);
    File.WriteAllText("users.json", json);
});
app.MapPut("/products/{id:int}", (int id, Product updatedProduct) =>
{
    var product = allproducts.FirstOrDefault(p => p.Id == id);
    if (product != null)
    {
        product.SetStock(updatedProduct.Stock);
        var json = JsonSerializer.Serialize(allproducts);
        File.WriteAllText("products.json", json);
        return Results.Ok(updatedProduct);
    }

    return Results.NotFound("Product not found");
});
app.MapPost("/orders", (Order newOrder) =>
{
    orders.Add(newOrder);
    var json = JsonSerializer.Serialize(orders);
    File.WriteAllText("orders.json", json);
    return Results.Ok(newOrder);
});
app.MapPut("/orders", (Order updatedOrder) =>
{
    var orderIndex = orders.FindIndex(order => order.OrderId == updatedOrder.OrderId);
    if (orderIndex >= 0)
    {
        orders[orderIndex] = updatedOrder;
    }
    else
    {
        orders.Add(updatedOrder);
    }

    var updatedJson = JsonSerializer.Serialize(orders);
    File.WriteAllText("orders.json", updatedJson);
    return Results.Ok(updatedOrder);
});

app.MapPut("/users/{id:int}", (int id, Person updatedUser) =>
{
    var userIndex = users.FindIndex(u => u.Id == id);
    if (userIndex >= 0)
    {
        users[userIndex] = updatedUser;
        var json = JsonSerializer.Serialize(users);
        File.WriteAllText("users.json", json);
        return Results.Ok(updatedUser);
    }

    return Results.NotFound("User not found");
});
app.MapDelete("/products/{id:int}", (int id) =>
{
    var product = allproducts.FirstOrDefault(p => p.Id == id);
    if (product != null)
    {
        allproducts.Remove(product);
        return Results.Ok();
    }
    return Results.NotFound("Product not found");
});

app.Run();