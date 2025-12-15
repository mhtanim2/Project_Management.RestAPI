using ProjectManagement.RestAPI.Entities.Enums;

namespace ProjectManagement.RestAPI.DTOs;

public class WorkTaskUpdateDto
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public Status? Status { get; set; }
    public int? AssignedToUserId { get; set; }
    public int? TeamId { get; set; }
    public DateTime? DueDate { get; set; }
    // [NotMapped] AssignedToUser/Team not included
}
