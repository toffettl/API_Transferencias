using API_Transferencias.Interfaces;
using API_Transferencias.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Transferencias.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TransferController : ControllerBase
{
    private readonly ITransferService _transferService;

    public TransferController(ITransferService transferService)
    {
        _transferService = transferService;
    }

    [HttpPost]
    public async Task<IActionResult> MakeTransfer([FromBody] Transfers transfer)
    {
        var result = await _transferService.MakeTransfer(transfer);
        if (!result.Success) return BadRequest(result.ErrorMessage);
        return Ok(result.Data);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTransferById(Guid id)
    {
        var result = await _transferService.GetTransferById(id);
        if (result == null) return NotFound("Transfer not found.");
        return Ok(result);
    }

    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetTransfersByUserId(Guid userId)
    {
        var result = await _transferService.GetTransfersByUserId(userId);
        if (!result.Success) return NotFound(result.ErrorMessage);
        return Ok(result.Data);
    }
}
