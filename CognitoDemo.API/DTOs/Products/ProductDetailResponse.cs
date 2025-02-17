namespace CognitoDemo.API.DTOs.Products
{
    public class ProductDetailResponse
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
    }
}
