namespace ProjectManagement.RestAPI.DTOs;

public class TeamUpdateDto
{
    public int Id { get; set; }
    public string? Name { get; set; } // optional for partial updates
    public string? Description { get; set; }
}
