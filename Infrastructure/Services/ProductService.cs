using Infrastructure.Interfaces;
using Infrastructure.Models;
using System.Text.Json;

namespace Infrastructure.Services;
//Skapar Product service klass genom interfacet.
public class ProductService : IProductService
{
    // Skapar listan som ska hantera produkterna och sätter dom på minnet.
    private readonly List<Product> _products = new();
    // Metod som behöver namn och pris på produkterna för att lägga in i listan
    public void AddProductToList(string name, decimal price)
    {
        // Felmedelande om det är null eller bara ett mellanslag.
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Produktnamnet får inte vara tomt eller ett mellanslag.");
            return;
        }
        // Felmeddelande om priset är mindre än 0.
        if (price < 0)
        {
            Console.WriteLine("Pris måste vara större än 0.");
            return;
        }
        //
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
        // Serialiserar produktlistan till en JSON-sträng som skrivs till Filen.
        File.WriteAllText(filePath, JsonSerializer.Serialize(_products, new JsonSerializerOptions { WriteIndented = true }));
    }
    // Metod som hämtar innehållet från filen.
    public void LoadFromFile(string filePath)
    {
        if (File.Exists(filePath))
        {
            // Gör en textsträng som vi läser in json innehållet från filen.
            var json = File.ReadAllText(filePath);
            // Deserialiserar JSON-strängen till en lista av produkter och listan lagras i en text sträng.
            var loaded = JsonSerializer.Deserialize<List<Product>>(json);
            // Om det finns något i listan så läggs det till i produktlistan.
            if (loaded != null)
                _products.AddRange(loaded);
        }
    }
}
