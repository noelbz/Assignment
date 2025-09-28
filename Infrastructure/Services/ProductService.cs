using Infrastructure.Interfaces;
using Infrastructure.Models;
using System.Text.Json;
using System.Runtime.CompilerServices;
using System.Xml;

namespace Infrastructure.Services;
//Skapar Product service klass genom interfacet.
public class ProductService : IProductService
{
    //Skapar listan som ska hantera produkterna och sätter dom på minnet.
    private readonly List<Product> _products = new();
    //Metod som behöver namn och pris på produkterna för att lägga in i listan
    public void AddProductToList(string name, decimal price)
    {
        //medelande om det är null eller bara ett mellanslag.
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Produktnamnet får inte vara tomt eller ett mellanslag.");
            return;
        }
        if (price < 0)
        {
            Console.WriteLine("Pris måste vara större än 0.");
            return;
        }

        var product = new Product
        {
            Name = name,
            Price = price
        };
        _products.Add(product);
    }
    //returnerar produktlistan
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
        // Söker igenom produktlistan och skriver ut alla produkter efter ID, Namn och Pris.
        foreach (var product in _products)
        {
            Console.WriteLine($"{product.Id} - {product.Name} - {product.Price}kr");
        }
    }
    // Metod som sparar innehållet till filen.
    public void SaveToFile(string filePath)
    {
        File.WriteAllText(filePath, JsonSerializer.Serialize(_products, new JsonSerializerOptions { WriteIndented = true }));
    }
    // Metod som laddar innehållet till filen.
    public void LoadFromFile(string filePath)
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
