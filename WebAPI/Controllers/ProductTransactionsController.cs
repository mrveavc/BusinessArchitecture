using Business.Abstracts;
using Core.Entities;
using Entities.DTOs;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
public class ProductTransactionsController : Controller
{
    private IProductTransactionService _productTransactionService;

    public ProductTransactionsController(IProductTransactionService productTransactionService)
    {
        _productTransactionService = productTransactionService;
    }
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var productTransactions = await _productTransactionService.GetAllAsync();

        return Ok(productTransactions.Select(productTransaction=>new ViewProductTransactionDto(productTransaction)));
    }
    [HttpGet("GetAllWithProduct")]

    public async Task<IActionResult> GetAllWithProduct()
    {

        return Ok(await _productTransactionService.GetAllWithProduct());
    }

    [HttpGet("GetById/{id}")]
    public async Task<IActionResult> Get(Guid id)
    {

        return Ok(await _productTransactionService.GetByIdAsync(id));
    }
    [HttpPost("Add")]
    public async Task<IActionResult> Add([FromBody] AddProductTransactionDto addProductTransactionDto)
    {
        return Ok(await _productTransactionService.AddAsync(addProductTransactionDto.GetProductTransaction()));
    }


    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] ProductTransaction productTransaction)
    {
        return Ok(await _productTransactionService.UpdateAsync(productTransaction));
    }

    [HttpDelete("DeleteById/{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _productTransactionService.DeleteByIdAsync(id);
        return Ok();
    }
}
