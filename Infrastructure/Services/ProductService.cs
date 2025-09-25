using Infrastructure.Interfaces;
using Infrastructure.Models;
using System.Text.Json;
using System.Runtime.CompilerServices;
using System.Xml;

namespace Infrastructure.Services;

public class ProductService : IProductService
{
    private readonly List<Product> _products = new();
    public void AddProductToList(string name, decimal price)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Produktnamnet kan inte bara vara tomt eller mellanslag.");
            return;
        }
        if (price < 0)
        {
            Console.WriteLine("Pris måste vara större än 0.");
        }

        var product = new Product
        {
            Name = name,
            Price = price
        };
        _products.Add(product);
    }

    public List<Product> GetAllProducts()
    {
        return _products;
    }
    public void ShowProductsFromList()
    {
        if(_products.Count == 0)
        {
            Console.WriteLine("Inga produkter finns i listan ännu.");
            //lägger return så att metoden slutar när de blev fel.
            return;
        }
        foreach (var product in _products)
        {
            Console.WriteLine($"{product.Id} - {product.Name} - {product.Price}");
        }
    }

    //Gör imorgon
    public void SaveToFile(string filePath)
    {
        File.WriteAllText(filePath, JsonSerializer.Serialize(_products, new JsonSerializerOptions { WriteIndented = true }));
    }

    public void LoadToFile(string filePath)
    {
        if (File.Exists(filePath))
        {
            var json = File.ReadAllText(filePath);
            var loaded = JsonSerializer.Deserialize<List<Product>>(json);
            if (loaded != null)
                _products.AddRange(loaded);
        }
    }
}
