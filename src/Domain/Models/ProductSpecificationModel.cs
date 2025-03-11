namespace ProductService.Domain.Models
{
    public class ProductSpecificationModel
    {
        public Guid Id { get; set; }  // ID-ul specificației
        public string Key { get; set; }  // Numele specificației
        public string Value { get; set; }  // Valoarea specificației
        public int ProductId { get; set; }  // ID-ul produsului asociat
    }
}
