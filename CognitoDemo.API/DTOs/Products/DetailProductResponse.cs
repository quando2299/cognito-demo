﻿namespace CognitoDemo.API.DTOs.Products;

public record DetailProductResponse
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }
}