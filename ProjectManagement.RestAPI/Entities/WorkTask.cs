using ProjectManagement.RestAPI.Entities.Common;
using ProjectManagement.RestAPI.Entities.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManagement.RestAPI.Entities;

public class WorkTask : BaseEntity
{
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public Status Status { get; set; }

    public int AssignedToUserId { get; set; }
    public User AssignedToUser { get; set; } = null!;

    public int TeamId { get; set; }
    public Team Team { get; set; } = null!;

    public DateTime? DueDate { get; set; }
}
