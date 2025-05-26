using API_Transferencias.Interfaces;
using API_Transferencias.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Transferencias.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var result = await _userService.Get(id);
        if (!result.Success) return NotFound(result.ErrorMessage);
        return Ok(result.Data);
    }

    [HttpPost]
    public async Task<IActionResult> Register([FromBody] User user)
    {
        var result = await _userService.Register(user);
        if (!result.Success) return BadRequest(result.ErrorMessage);
        return CreatedAtAction(nameof(Get), new { id = result.Data.UserId }, result.Data);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] User user)
    {
        user.UserId = id;
        var result = await _userService.Update(user);
        if (!result.Success) return NotFound(result.ErrorMessage);
        return Ok(result.Data);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _userService.Delete(id);
        if (!result.Success) return NotFound(result.ErrorMessage);
        return Ok(result.Data);
    }
}

