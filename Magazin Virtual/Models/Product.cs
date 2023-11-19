namespace Seminar_2.Models
{
    public class Product
    {
        public Product()
        {
            Name = string.Empty;
            Description = string.Empty;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public string? ImagePath { get; set; }

        public static List<Product> GetAll()
        {
            var products = new List<Product>();

            products.Add(new Product { Id = 1, Name = "Product1", Description = "D1", ImagePath = "img/blender.PNG", IsAvailable = true, Price = 20 });
            products.Add(new Product { Id = 2, Name = "Product2", Description = "D2", ImagePath = "img/cantar.PNG", IsAvailable = true, Price = 50 });
            products.Add(new Product { Id = 3, Name = "Product3", Description = "D3", ImagePath = "img/termos.PNG", IsAvailable = true, Price = 100 });

            return products;
        }
    }
}
