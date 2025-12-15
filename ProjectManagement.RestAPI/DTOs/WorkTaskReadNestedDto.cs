using ProjectManagement.RestAPI.Entities.Enums;

namespace ProjectManagement.RestAPI.DTOs;

// Read with nested related data (optional)
public class WorkTaskReadNestedDto
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public Status Status { get; set; }
    public int AssignedToUserId { get; set; }
    public int TeamId { get; set; }
    public DateTime? DueDate { get; set; }

    // Nested related entities (optional)
    public UserReadDto? AssignedToUser { get; set; }
    public TeamReadDto? Team { get; set; }

    public DateTime? CreatedDate { get; set; }
    public int? CreatedByUserId { get; set; }
    public DateTime? LastModifiedDate { get; set; }
    public int? ModifiedBy { get; set; }

}
