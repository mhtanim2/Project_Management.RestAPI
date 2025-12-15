namespace ProjectManagement.RestAPI.DTOs;

public class TeamReadNestedDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime? CreatedDate { get; set; }
    public int? CreatedByUserId { get; set; }
    public DateTime? LastModifiedDate { get; set; }
    public int? ModifiedBy { get; set; }

    // Optional: include related data
    // public List<WorkTaskReadDto> Tasks { get; set; } = new List<WorkTaskReadDto>();

}
