using System.Text.Json.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Models
{
    public class ProductCategoryModel
    {
        [BsonId]
        [JsonIgnore]
        public Guid Id { get; set; }
        public string Category{ get; set;}
    }
}