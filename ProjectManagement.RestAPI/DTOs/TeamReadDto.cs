namespace ProjectManagement.RestAPI.DTOs;

public class TeamReadDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime? CreatedDate { get; set; }
    public int? CreatedByUserId { get; set; }
    public DateTime? LastModifiedDate { get; set; }
    public int? ModifiedBy { get; set; }
}
