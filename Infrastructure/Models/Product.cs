﻿namespace Infrastructure.Models;
// Produkt Klassen
public class Product
{
    // Produkternas egenskaper
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public decimal Price { get; set; }

}
