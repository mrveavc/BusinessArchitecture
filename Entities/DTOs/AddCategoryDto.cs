using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Entities.Models;

namespace Entities.DTOs;

public class AddCategoryDto
{
    public string Name { get; set; }

    public Category GetCategory()
    {
        return new()
        {
            Name = Name,
            
        };
    }
}
public class ViewCategoryDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public ViewCategoryDto(Category category)
    {
        Id = category.Id;
        Name = category.Name;
    
    }
}