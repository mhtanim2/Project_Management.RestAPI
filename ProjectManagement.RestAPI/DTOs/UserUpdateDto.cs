using ProjectManagement.RestAPI.Entities.Enums;

namespace ProjectManagement.RestAPI.DTOs;

public class UserUpdateDto
{
    public int Id { get; set; }
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public Role? Role { get; set; }
    // Audit fields typically not updated here
}
