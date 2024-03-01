using Business.Abstracts;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]

public class ClaimController : Controller
{
    private readonly IClaimService _claimService;

    public ClaimController(IClaimService claimService)
    {
        _claimService = claimService;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _claimService.GetAllAsync());
    }


    [HttpGet("GetById/{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        return Ok(await _claimService.GetByIdAsync(id));
    }

    [HttpPost("Add")]
    public async Task<IActionResult> Add([FromBody] Claim claim)
    {
        return Ok(await _claimService.AddAsync(claim));
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] Claim claim)
    {
        return Ok(await _claimService.UpdateAsync(claim));
    }

    [HttpDelete("DeleteById/{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _claimService.DeleteByIdAsync(id);
        return Ok();
    }
}

