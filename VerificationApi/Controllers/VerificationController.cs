using Microsoft.AspNetCore.Mvc;
using VerificationApi.Models.DTOModel;
using VerificationApi.Models.EntityModel;
using VerificationApi.Services.Interfaces;

namespace VerificationApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VerificationController : ControllerBase
{
    private readonly IVerificationService _service;

    public VerificationController(IVerificationService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromForm] CreateVerificationRequest dto)
    {
        var result = await _service.CreateVerificationRequestAsync(dto);

        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _service.GetByIdAsync(id);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpPut("{id}/status")]
    public async Task<IActionResult> UpdateStatus(int id, [FromQuery] VerificationStatus status)
    {
        var result = await _service.UpdateStatusAsync(id, status);

        if (result == null)
            return NotFound();

        return Ok("Status Updated");
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _service.GetAllRequestsAsync();
        return Ok(result);
    }
}