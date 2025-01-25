using System.ComponentModel.DataAnnotations;

namespace CognitoDemo.API.DTOs.Products;

public class CreateProductRequest
{
    [Required]
    [StringLength(200)]
    public required string Name { get; set; }

    [Required]
    [Range(0.01, double.MaxValue)]
    public required decimal Price { get; set; }

    [StringLength(1000)] 
    public string? Description { get; set; } = string.Empty;
}