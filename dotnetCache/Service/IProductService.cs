using dotnetCache.Models;

namespace dotnetCache.Service;

public interface IProductService
{
    IEnumerable<Product> GetProducts();
}
