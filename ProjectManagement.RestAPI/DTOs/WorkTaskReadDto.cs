using ProjectManagement.RestAPI.Entities.Enums;

namespace ProjectManagement.RestAPI.DTOs;

public class WorkTaskReadDto
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public Status Status { get; set; }
    public int AssignedToUserId { get; set; }
    public int TeamId { get; set; }
    public DateTime? DueDate { get; set; }

    // Optional audit fields
    public DateTime? CreatedDate { get; set; }
    public int? CreatedByUserId { get; set; }
    public DateTime? LastModifiedDate { get; set; }
    public int? ModifiedBy { get; set; }

}
