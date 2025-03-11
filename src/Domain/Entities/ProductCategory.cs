namespace ProductService.Domain.Entities
{
    public class ProductCategory
    {
        public int Id { get; set; }  // ID-ul categoriei
        public string Name { get; set; }  // Numele categoriei
        public ICollection<Product> Products { get; set; }  // Produsele din această categorie
    }
}
