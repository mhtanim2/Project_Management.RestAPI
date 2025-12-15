using Microsoft.AspNetCore.Mvc;
using ProjectManagement.RestAPI.DTOs;
using ProjectManagement.RestAPI.Service.Interface;

namespace ProjectManagement.RestAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WorkTasksController : ControllerBase
{
    private readonly IWorkTaskService _workTaskService;

    public WorkTasksController(IWorkTaskService workTaskService)
    {
        _workTaskService = workTaskService;
    }

    [HttpPost]
    public async Task<ActionResult<WorkTaskReadDto>> CreateAsync([FromBody] WorkTaskCreateDto dto)
    {
        var id = await _workTaskService.CreateAsync(dto);
        var created = await _workTaskService.GetByIdAsync(id);
        
        if (created == null)
            return CreatedAtAction(nameof(GetById), new { id }, null);

        return CreatedAtAction(nameof(GetById), new { id }, created);
    }

    [HttpGet]
    public async Task<ActionResult<ICollection<WorkTaskReadDto>>> GetAllAsync()
    {
        var result = await _workTaskService.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("search")]
    public async Task<ActionResult<ICollection<WorkTaskReadDto>>> SearchAsync([FromQuery] WorkTaskFilterDto filter)
    {
        var result = await _workTaskService.SearchAsync(filter);
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<WorkTaskReadDto>> GetById(int id)
    {
        var result = await _workTaskService.GetByIdAsync(id);
        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] WorkTaskUpdateDto dto)
    {
        await _workTaskService.UpdateAsync(id, dto);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _workTaskService.DeleteAsync(id);
        return NoContent();
    }
}
