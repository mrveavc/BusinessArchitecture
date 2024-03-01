
using Business.Abstracts;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]

public class UserClaimsController : Controller
{
    private readonly IUserClaimService _userClaimService;

    public UserClaimsController(IUserClaimService userClaimService)
    {
        _userClaimService = userClaimService;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _userClaimService.GetAllAsync());
    }


    [HttpGet("GetById/{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        return Ok(await _userClaimService.GetByIdAsync(id));
    }

    [HttpGet("GetByUserId/{id}")]
    public async Task<IActionResult> GetByUserId(Guid id)
    {
        return Ok(await _userClaimService.GetByUserIdAsync(id));
    }

    [HttpPost("Add")]
    public async Task<IActionResult> Add([FromBody] UserClaim userClaim)
    {
        return Ok(await _userClaimService.AddAsync(userClaim));
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] UserClaim userClaim)
    {
        return Ok(await _userClaimService.UpdateAsync(userClaim));
    }

    [HttpDelete("DeleteById/{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _userClaimService.DeleteByIdAsync(id);
        return Ok();
    }
}
