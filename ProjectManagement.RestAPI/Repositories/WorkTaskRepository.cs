using Microsoft.EntityFrameworkCore;
using ProjectManagement.RestAPI.Contracts.Persistence;
using ProjectManagement.RestAPI.DataContext;
using ProjectManagement.RestAPI.Entities;

namespace ProjectManagement.RestAPI.Repositories;

public class WorkTaskRepository : GenericRepository<WorkTask>, IWorkTaskRepository
{
    private readonly ApplicationDBContext _context;

    public WorkTaskRepository(ApplicationDBContext context) : base(context)
    {
        _context = context;
    }

    public async Task<WorkTask> GetByTitleAsync(string title)
    {
        return await _context.WorkTasks.AsNoTracking()
            .FirstOrDefaultAsync(wt => wt.Title == title);
    }

    public async Task<IReadOnlyList<WorkTask>> SearchAsync(
        Entities.Enums.Status? status,
        int? assignedToUserId,
        int? teamId,
        DateTime? dueDateFrom,
        DateTime? dueDateTo)
    {
        var query = _context.WorkTasks
            .Include(wt => wt.AssignedToUser)
            .Include(wt => wt.Team)
            .AsNoTracking()
            .AsQueryable();

        // Apply filters conditionally
        if (status.HasValue)
        {
            query = query.Where(wt => wt.Status == status.Value);
        }

        if (assignedToUserId.HasValue)
        {
            query = query.Where(wt => wt.AssignedToUserId == assignedToUserId.Value);
        }

        if (teamId.HasValue)
        {
            query = query.Where(wt => wt.TeamId == teamId.Value);
        }

        if (dueDateFrom.HasValue)
        {
            query = query.Where(wt => wt.DueDate >= dueDateFrom.Value);
        }

        if (dueDateTo.HasValue)
        {
            query = query.Where(wt => wt.DueDate <= dueDateTo.Value);
        }

        return await query.ToListAsync();
    }
}
