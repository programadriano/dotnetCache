using dotnetCache.Models;

namespace dotnetCache.Service
{
    public class ProductService : IProductService
    {
        public IEnumerable<Product> GetProducts()
        {
            var products = new List<Product>
        {
            new() { Id = 1, Name = "Product 1", Price = 19.99m },
            new() { Id = 2, Name = "Product 2", Price = 29.99m },
            new() { Id = 3, Name = "Product 3", Price = 39.99m }
        };

            return products;
        }
    }
}
