using ProjectManagement.RestAPI.DTOs;
using ProjectManagement.RestAPI.Services.Interfaces;

namespace ProjectManagement.RestAPI.Services;

public class TeamService : ITeamService
{
    public TeamService()
    {
        
    }
    public Task<int> CreateAsync(TeamCreateDto dto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<TeamReadDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<TeamReadDto?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(int id, TeamUpdateDto dto)
    {
        throw new NotImplementedException();
    }
}
