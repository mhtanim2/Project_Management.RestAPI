namespace ProjectManagement.RestAPI.Entities.Common;

public abstract class BaseEntity
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public int? CreatedByUserId { get; set; }
    public DateTime? LastModifiedDate { get; set; }
    public int? ModifiedByUserId { get; set; }
}
