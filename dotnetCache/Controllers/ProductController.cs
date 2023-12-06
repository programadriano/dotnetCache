
using dotnetCache.Models;
using dotnetCache.Service;
using Microsoft.AspNetCore.Mvc;

namespace dotnetCache.Controllers;


[ApiController]
[Route("[controller]")]
public class ProductController(ICacheService cacheService, IProductService productService) : ControllerBase
{
    private readonly ICacheService _cacheService = cacheService;
    private readonly IProductService _productService = productService;

    [HttpGet]
    public IActionResult GetProduct()
    {
        var key = "productList";
        var cachedProduct = _cacheService.Get(key);

        if (cachedProduct != null)
        {
            return Ok(cachedProduct);
        }

        var productList = _productService.GetProducts();

        _cacheService.Set(key, productList);

        return Ok(productList);
    }

    [HttpPost("{key}")]
    public IActionResult SetProduct(string key, [FromBody] Product product)
    {
        _cacheService.Set(key, product);
        return Ok($"Produto com chave '{key}' adicionado ao cache.");
    }

    [HttpDelete("{key}")]
    public IActionResult RemoveProduct(string key)
    {
        _cacheService.Remove(key);
        return Ok($"Produto com chave '{key}' removido do cache.");
    }
}
