
using System.Text.Json.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Models
{
    public class ProductModel
    {
        [BsonId]
        [JsonIgnore]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string Category { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string ImageUrl { get; set; }
        public double Rating { get; set; }
        public bool IsActive { get; set; }
        public decimal? DiscountPrice { get; set; }
    }
}