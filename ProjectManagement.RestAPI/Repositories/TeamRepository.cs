using ProjectManagement.RestAPI.Contracts.Persistence;
using ProjectManagement.RestAPI.DataContext;
using ProjectManagement.RestAPI.Entities;

namespace ProjectManagement.RestAPI.Repositories;

public class TeamRepository : GenericRepository<Team>, ITeamRepository
{
    public TeamRepository(ApplicationDBContext context) : base(context)
    {
    }
}
