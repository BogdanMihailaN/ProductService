namespace ProductService.Domain.Entities
{
    public class ProductSpecification
    {
        public int Id { get; set; }  // ID-ul specificației
        public string Key { get; set; }  // Numele specificației
        public string Value { get; set; }  // Valoarea specificației
        public int ProductId { get; set; }  // ID-ul produsului asociat
        public Product Product { get; set; }  // Produsul asociat
    }
}
