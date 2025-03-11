namespace ProductService.Domain.Models
{
    public class ProductImageModel
    {
        public Guid Id { get; set; }  // ID-ul imaginii
        public string Url { get; set; }  // URL-ul imaginii
        public bool IsPrimary { get; set; }  // Indică dacă este imaginea principală a produsului
        public int ProductId { get; set; }  // ID-ul produsului asociat
    }
}
