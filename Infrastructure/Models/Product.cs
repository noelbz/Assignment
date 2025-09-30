namespace Infrastructure.Models;
public class Product
{
    // Produktens egenskaper som användaren ska mata in för att skapa en produkt (namn och pris).

    // Ger ett unikt ID till varje produkt.
    public Guid Id { get; set; } = Guid.NewGuid();
    // Namn på produkten.
    public string Name { get; set; }
    // Pris på produkten.
    public decimal Price { get; set; }

}
