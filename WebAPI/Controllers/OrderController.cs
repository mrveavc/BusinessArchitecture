using Business.Abstracts;
using Core.Entities;
using Entities.DTOs;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
namespace WebAPI.Controllers;

[Route("api/[controller]")]

public class OrderController : Controller
{
    private readonly IOrderService _orderService;

    public OrderController(
        IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _orderService.GetAllAsync());
    }
    [HttpGet("GetAllWithDetails")]
    public async Task<IActionResult> GetAllWithDetailsAsync()
    {
        return Ok(await _orderService.GetAllWithDetailsAsync());
    }

    [HttpGet("GetById/{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        return Ok(await _orderService.GetByIdAsync(id));
    }

    [HttpPost("Add")]
    public async Task<IActionResult> Add([FromBody] AddOrderDto addOrderDto)
    {
        return Ok(await _orderService.AddAsync(addOrderDto));
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] Order order)
    {
        return Ok(await _orderService.UpdateAsync(order));
    }

    [HttpDelete("DeleteById/{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _orderService.DeleteByIdAsync(id);
        return Ok();
    }






}
