using Infrastructure.Models;
namespace Infrastructure.Interfaces;

public interface IProductService
{
    // Hämtar Produktlistan
    List<Product> GetAllProducts();
    // Lägger till i Produktlistan.
    void AddProductToList(string name, decimal price);
    // Visar Produktlistan.
    void ShowProductsFromList();
    // Sparar till en json fil.
    void SaveToFile(string filePath);
    // Hämtar från json fil och visar Produktlistan.
    void LoadFromFile(string filePath);
}
