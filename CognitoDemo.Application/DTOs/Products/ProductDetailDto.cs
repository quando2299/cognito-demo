using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CognitoDemo.Application.DTOs.Products
{
    public class ProductDetailDto
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
    }
}
