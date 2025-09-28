using Infrastructure.Models;
namespace Infrastructure.Interfaces;

public interface IProductService
{
    List<Product> GetAllProducts();
    void AddProductToList(string name, decimal price);
    void ShowProductsFromList();
    void SaveToFile(string filePath);
    void LoadFromFile(string filePath);
}
