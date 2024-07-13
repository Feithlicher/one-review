using OneReview.Domain;

namespace OneReview.Services;

public class ProductsService
{
    // private static readonly List<Product> ProductsRepository = [];
    private static readonly List<Product> ProductsRepository = new List<Product>();
    
    public void Create(Product product)
    {
        // store the product in the database
    }

    public Product Get(Guid id)
    {
        return null;
    }
}