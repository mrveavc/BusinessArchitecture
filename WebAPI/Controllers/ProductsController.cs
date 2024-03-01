using Business.Abstracts;
using Core.Entities;
using Entities.DTOs;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
public class ProductsController : Controller
{
    private readonly IProductService _productService;
    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var products = await _productService.GetAllAsync();
        return Ok(products.Select(product => new ViewProductDto(product)));
    }
    [HttpGet("GetAllWithCategory")]
    public async Task<IActionResult> GetAllWithCAtegory()
    {
        return Ok(await _productService.GetAllWithCAtegory());
        //return Ok(_productService.GetAll(include: product => product.Include(p => p.Category)));
    }

    [HttpGet("GetById/{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        return Ok(await _productService.GetByIdAsync(id));
    }

    [HttpPost("Add")]
    public IActionResult Add([FromBody]AddProductDto addProductDto)
    {
        return Ok(_productService.Add(addProductDto.GetProduct()));
    }

    [HttpPut("Update")]
    public IActionResult Update([FromBody] Product product)
    {
        return Ok(_productService.Update(product));
    }

    [HttpDelete("DeleteById/{id}")]
    public IActionResult Delete(Guid id)
    {
        _productService.DeleteById(id);
        return Ok();
    }
}
