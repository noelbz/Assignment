using Infrastructure.Interfaces;
using Infrastructure.Services;

namespace Assignment;
class Program
{
    static void Main(string[] args)
    {
        // Kallar på klassens typ (som är interfacet) och skapar självaste objektet utifrån klassen.
        // Har nu åtkomst till alla metoderna i ProductService.
        IProductService productService = new ProductService();
        // Sökvägen till filen där alla produkter sparas därefter.
        string filePath = "product.json";
        // Metoden läser innehållet som finns från filen och laddar upp produkterna till listan.
        productService.LoadFromFile(filePath);
        bool isRunning = true;
        // Loopar menyn tills användaren väljer att avsluta.
        while (isRunning)
        {
            Console.Clear();
            // Menyval
            Console.WriteLine("\n---MENY---");
            Console.WriteLine("[1]Lägg till en produkt");
            Console.WriteLine("[2]Visa produkter");
            Console.WriteLine("[3]Spara produkter");
            Console.WriteLine("[4]Avsluta");
            Console.Write("Välj: ");
            Console.ResetColor();
            string choice = Console.ReadLine();
            // Ger olika utfall baserat på inmatningen av användaren.
            switch (choice)
            {
                case "1":
                    Console.WriteLine("Skriv namn på produkten: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Skriv priset på produkten: ");
                    // Kollar att inmatningen stämmer med decimal datatypen.
                    if (decimal.TryParse(Console.ReadLine(), out decimal price))
                    {
                        // Metoden lägger produkten i listan som getts ett namn och pris.
                        productService.AddProductToList(name, price);
                    }
                    else
                    {
                        // Felmeddelande
                        Console.WriteLine("Ogiltigt pris, försök igen.");
                        Console.ReadKey();
                    }
                    break;
                case "2":
                    // Metoden går igenom listan och skriver ut alla produkter som finns.
                    productService.ShowProductsFromList();
                    Console.WriteLine("Tryck valfri knapp för att återgå till menyn.");
                    Console.ReadKey();
                    break;
                case "3":
                    // Sparar hela listan till json fil.
                    productService.SaveToFile(filePath);
                    Console.WriteLine("Produkterna har blivit sparade! Tryck valfri knapp för att återgå till menyn.");
                    Console.ReadKey();
                    break;
                case "4":
                    productService.SaveToFile(filePath);
                    Console.WriteLine("Programmet avslutas nu...");
                    return;
                default:
                    Console.WriteLine("Fel val, försök igen...");
                    Console.ReadKey();
                    break;

            }

        }

    }
}