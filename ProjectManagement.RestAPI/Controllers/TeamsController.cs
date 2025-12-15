using Microsoft.AspNetCore.Mvc;
using ProjectManagement.RestAPI.DTOs;
using ProjectManagement.RestAPI.Services.Interfaces;

namespace ProjectManagement.RestAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TeamsController : ControllerBase
{
    private readonly ITeamService _teamService;

    public TeamsController(ITeamService teamService)
    {
        _teamService = teamService;
    }

    [HttpPost]
    public async Task<ActionResult<TeamReadDto>> CreateAsync([FromBody] TeamCreateDto dto)
    {
        var id = await _teamService.CreateAsync(dto);
        var created = await _teamService.GetByIdAsync(id);

        if (created == null)
            return CreatedAtAction(nameof(GetById), new { id }, null);

        return CreatedAtAction(nameof(GetById), new { id }, created);
    }

    [HttpGet]
    public async Task<ActionResult<ICollection<TeamReadDto>>> GetAllAsync()
    {
        var result = await _teamService.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<TeamReadDto>> GetById(int id)
    {
        var result = await _teamService.GetByIdAsync(id);
        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] TeamUpdateDto dto)
    {
        await _teamService.UpdateAsync(id, dto);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _teamService.DeleteAsync(id);
        return NoContent();
    }
}
