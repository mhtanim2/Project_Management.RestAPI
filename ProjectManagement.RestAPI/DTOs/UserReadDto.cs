using ProjectManagement.RestAPI.Entities.Enums;

namespace ProjectManagement.RestAPI.DTOs;

public class UserReadDto
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public Role Role { get; set; }
    // Optional audit
    public DateTime? CreatedDate { get; set; }
    public int? CreatedByUserId { get; set; }
    public DateTime? LastModifiedDate { get; set; }
    public int? ModifiedBy { get; set; }
}
