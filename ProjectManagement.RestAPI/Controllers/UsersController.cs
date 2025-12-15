using Microsoft.AspNetCore.Mvc;
using ProjectManagement.RestAPI.DTOs;
using ProjectManagement.RestAPI.Services.Interfaces;

namespace ProjectManagement.RestAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<ActionResult<UserReadDto>> CreateAsync([FromBody] UserCreateDto dto)
    {
        var id = await _userService.CreateAsync(dto);

        var createdUser = await _userService.GetByIdAsync(id);
        if (createdUser == null)
        {
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }

        return CreatedAtAction(nameof(GetById), new { id = id }, createdUser);
    }

    [HttpGet]
    public async Task<ActionResult<ICollection<UserReadDto>>> GetAllAsync()
    {
        var users = await _userService.GetAllAsync();
        return Ok(users);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<UserReadDto>> GetById(int id)
    {
        var user = await _userService.GetByIdAsync(id);
        if (user == null)
            return NotFound();

        return Ok(user);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] UserUpdateDto dto)
    {
        await _userService.UpdateAsync(id, dto);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _userService.DeleteAsync(id);
        return NoContent();
    }
}