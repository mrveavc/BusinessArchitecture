using System.Linq;
using Business.Abstracts;
using Core.Entities;
using Entities.DTOs;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
public class CategoriesController : Controller
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(
        ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var categories = await _categoryService.GetAllAsync();

        return Ok(categories.Select(category => new ViewCategoryDto(category)));
    }
    [HttpGet("GetAllWithProducts")]
    public async Task<IActionResult> GetAllWithProducts()
    {
        return Ok(await _categoryService.GetAllWithProductsAsync());
    }

    [HttpGet("GetById/{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        return Ok(await _categoryService.GetByIdAsync(id));
    }

    [HttpPost("Add")]
    public async Task<IActionResult> Add([FromBody] AddCategoryDto addCategoryDto)
    {
        return Ok(await _categoryService.AddAsync(addCategoryDto.GetCategory()));
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] Category category)
    {
        return Ok(await _categoryService.UpdateAsync(category));
    }

    [HttpDelete("DeleteById/{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _categoryService.DeleteByIdAsync(id);
        return Ok();
    }
}
