namespace ProductService.Domain.Entities
{
    public class ProductImage
    {
        public int Id { get; set; }  // ID-ul imaginii
        public string Url { get; set; }  // URL-ul imaginii
        public bool IsPrimary { get; set; }  // Indică dacă este imaginea principală a produsului
        public int ProductId { get; set; }  // ID-ul produsului asociat
        public Product Product { get; set; }  // Produsul asociat
    }
}
