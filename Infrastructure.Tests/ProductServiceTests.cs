using Infrastructure.Models;
using Infrastructure.Services;
using Xunit;

namespace Infrastructure.Tests;
public class ProductServiceTests
{
    // Talar om att det är ett test
    [Fact]
    //Det vi vill testa och vad den ska göra
    public void AddProductToList_ShouldAddProduct()
    {
        // Arrange - förbereder testet
        var productService = new ProductService();

        var productName = "Test Product";
        var productPrice = 9.99m;
        // Act - utför det vi vill testa
        productService.AddProductToList(productName, productPrice);
        // Assert - verifierar att resultatet är som förväntat
        var allProducts = productService.GetAllProducts();
        Assert.Single(allProducts);
        Assert.Equal(productName, allProducts[0].Name);
        Assert.Equal(productPrice, allProducts[0].Price);
    }
}
