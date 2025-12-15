using ProjectManagement.RestAPI.Entities.Enums;

namespace ProjectManagement.RestAPI.DTOs;

// 3) WorkTask DTOs
public class WorkTaskCreateDto
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public Status Status { get; set; }
    public int AssignedToUserId { get; set; }
    public int TeamId { get; set; }
    public DateTime? DueDate { get; set; }
    // NotMapped navigation properties are typically not included here
}
