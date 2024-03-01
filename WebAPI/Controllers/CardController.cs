using Business.Abstracts;
using Core.Entities;
using Entities.DTOs;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]

public class CardController : Controller
{
    private readonly ICardService _cardService;

    public CardController(ICardService cardService)
    {
        _cardService = cardService;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var cards = await _cardService.GetAllAsync();

        return Ok(cards.Select(card => new ViewCardDto(card)));
        //return Ok(await _cardService.GetAllAsync());
    }


    [HttpGet("GetById/{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        return Ok(await _cardService.GetByIdAsync(id));
    }

 
    [HttpPost("Add")]
    public async Task<IActionResult> Add([FromBody] AddCardDto addCardDto)
    {
        return Ok(await _cardService.AddAsync(addCardDto.GetCard()));
    }
    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] Card card)
    {
        return Ok(await _cardService.UpdateAsync(card));
    }

    [HttpDelete("DeleteById/{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _cardService.DeleteByIdAsync(id);
        return Ok();
    }
}
