namespace ProductCRUD.Models
{
    public class Product
    {
        public Guid? Id { get; set; } = null;
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
        public string? ImageLink { get; set; } = null;
    }
}
