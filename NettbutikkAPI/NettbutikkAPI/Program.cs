using System.Text.Json;
using NettbutikkAPI;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseHttpsRedirection();
app.UseStaticFiles();
var datamanager = new DataManager();
List<Product> Allproducts;
if (File.Exists("products.json"))
{
    var json = File.ReadAllText("products.json");
    Allproducts = JsonSerializer.Deserialize<List<Product>>(json);
}
else
{
    Allproducts = datamanager.GetProducts();
}
app.MapGet("/products", () => Allproducts);
app.MapPost("/products", (Product newProduct) =>
{
    Allproducts.Add(newProduct);
    var json = JsonSerializer.Serialize(Allproducts);
    File.WriteAllText("products.json", json);
});
app.MapPut("/products", (List<Product> updatedProducts) =>
{
    foreach (var updatedProduct in updatedProducts)
    {
        var productIndex = Allproducts.FindIndex(p => p.Id == updatedProduct.Id);
        if (productIndex >= 0)
        {
            Allproducts[productIndex] = updatedProduct;
        }
    } 
    var json = JsonSerializer.Serialize(Allproducts); 
    File.WriteAllText("products.json", json); 
});
app.Run();

