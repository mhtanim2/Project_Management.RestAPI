using ProjectManagement.RestAPI.Entities.Enums;

namespace ProjectManagement.RestAPI.DTOs;

public class WorkTaskFilterDto
{
    public Status? Status { get; set; }
    public int? AssignedToUserId { get; set; }
    public int? TeamId { get; set; }
    public DateTime? DueDateFrom { get; set; }
    public DateTime? DueDateTo { get; set; }
}
