using Microsoft.AspNetCore.Mvc;

using OneReview.Domain;
using OneReview.Services;

namespace OneReview.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController(ProductsService productsService) : ControllerBase
{
    private readonly ProductsService _productsService = productsService;

    [HttpPost]
    public IActionResult Create(CreateProductRequest request)
    {
        // mapping to internal representation
        Product product = request.ToDomain();
        
        // create the product
        _productsService.Create(product);

        //mapping to external representation
        // return 201 created response
        return CreatedAtAction(
            nameof(Get),
            new { ProductId = product.Id },
            value: ProductResponse.FromDomain(product)
        );
    }




    [HttpGet("{productId:guid}")]
    public IActionResult Get(Guid productId)
    {
        // Invoking the user case
        Product product = _productsService.Get(productId);
        
        // return 200 ok response
        return Ok(ProductResponse.FromDomain(product));
    }







    public record CreateProductRequest(string Name, string Category, string SubCategory)
    {
        public Product ToDomain()
        {
            return new Product()
            {
                Name = Name,
                Category = Category,
                SubCategory = SubCategory
            };
        }
    }

    public record ProductResponse(Guid Id, string Name, string Category, string SubCategory)
    {
        public static ProductResponse FromDomain(Product product)
        {
            return new ProductResponse(product.Id, product.Name, product.Category, product.SubCategory);
        }
    }
    
}