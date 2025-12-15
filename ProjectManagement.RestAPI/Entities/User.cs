using ProjectManagement.RestAPI.Entities.Common;
using ProjectManagement.RestAPI.Entities.Enums;

namespace ProjectManagement.RestAPI.Entities;

public class User : BaseEntity
{
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public Role Role { get; set; }

    // Navigation
    public ICollection<WorkTask> AssignedTasks { get; set; } = new List<WorkTask>();
    public ICollection<TeamMember> TeamMembers { get; set; } = new List<TeamMember>();
}
