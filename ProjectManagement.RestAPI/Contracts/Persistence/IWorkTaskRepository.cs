using ProjectManagement.RestAPI.Entities;
using ProjectManagement.RestAPI.Entities.Enums;

namespace ProjectManagement.RestAPI.Contracts.Persistence;

public interface IWorkTaskRepository : IGenericRepository<WorkTask>
{
    Task<WorkTask> GetByTitleAsync(string title);
    Task<IReadOnlyList<WorkTask>> SearchAsync(
        Status? status,
        int? assignedToUserId,
        int? teamId,
        DateTime? dueDateFrom,
        DateTime? dueDateTo);
}
