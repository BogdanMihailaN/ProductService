﻿namespace ProductService.Domain.Models
{
    public class ProductModel
    {
        public int Id { get; set; }  // ID-ul unic al produsului
        public string Name { get; set; }  // Numele produsului
        public string Description { get; set; }  // Descrierea detaliată a produsului
        public decimal Price { get; set; }  // Prețul produsului
        public decimal Discount { get; set; }  // Reducerea aplicată (dacă există)
        public DateTime CreatedAt { get; set; }  // Data adăugării produsului
        public DateTime UpdatedAt { get; set; }  // Data ultimei actualizări a produsului
        public int CategoryId { get; set; }  // ID-ul categoriei (FK)
    }
}