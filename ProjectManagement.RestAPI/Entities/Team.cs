using ProjectManagement.RestAPI.Entities.Common;

namespace ProjectManagement.RestAPI.Entities;

public class Team : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    // Navigation
    public ICollection<WorkTask> Tasks { get; set; } = new List<WorkTask>();
    public ICollection<TeamMember> TeamMembers { get; set; } = new List<TeamMember>();
}
