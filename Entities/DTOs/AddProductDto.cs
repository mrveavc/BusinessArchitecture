using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Entities.Models;

namespace Entities.DTOs;

public class AddProductDto
{
    public Guid CategoryId { get; set; }
    public required string Name { get; set; }
    public required decimal Price { get; set; }
    public string? Description { get; set; }
    public Product GetProduct()
    {
        return new()
        {
            CategoryId = CategoryId,
            Name = Name,
            Price = Price,
            Description = Description,
        };
    }
}

public class ViewProductDto
{
    public Guid CategoryId { get; set; }
    public  string Name { get; set; }
    public  decimal Price { get; set; }
    public string? Description { get; set; }

    public ViewProductDto(Product product)
    {
        CategoryId = product.CategoryId;
        Name = product.Name;
        Price = product.Price;
        Description = product.Description;
       
    }
}