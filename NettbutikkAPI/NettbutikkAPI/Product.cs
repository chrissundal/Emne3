﻿namespace NettbutikkAPI;

public class Product
{
    public int Id { get; private set; }
    public string NameOfProduct { get; private set; }
    public string TypeOfProduct { get; private set; }
    public int Price { get; private set; }
    public int Stock { get; private set; }
    public string ImageUrl { get; private set; }

    public Product(int id, string nameOfProduct, string typeOfProduct, int price, int stock, string imageUrl)
    {
        Id = id;
        NameOfProduct = nameOfProduct;
        TypeOfProduct = typeOfProduct;
        Price = price;
        Stock = stock;
        ImageUrl = imageUrl;
    }
}