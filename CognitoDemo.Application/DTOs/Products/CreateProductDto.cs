﻿namespace CognitoDemo.Application.DTOs.Products;

public class CreateProductDto
{
    public required string Name { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }
}