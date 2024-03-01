using Business.Abstracts;
using Core.Entities;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;


namespace WebAPI.Controllers;


[Route("api/[controller]")]
public class CardTypeController : Controller
{
    private readonly ICardTypeService _cardTypeService;

    public CardTypeController(
        ICardTypeService cardTypeService)
    {
        _cardTypeService = cardTypeService;
    }
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _cardTypeService.GetAllAsync());
    }


    [HttpGet("GetById/{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        return Ok(await _cardTypeService.GetByIdAsync(id));
    }

    [HttpPost("Add")]
    public async Task<IActionResult> Add([FromBody] CardType cardType)
    {
        return Ok(await _cardTypeService.AddAsync(cardType));
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] CardType cardType)
    {
        return Ok(await _cardTypeService.UpdateAsync(cardType));
    }

    [HttpDelete("DeleteById/{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _cardTypeService.DeleteByIdAsync(id);
        return Ok();
    }

}
