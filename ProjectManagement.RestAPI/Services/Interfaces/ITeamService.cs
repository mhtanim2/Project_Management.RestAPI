using ProjectManagement.RestAPI.DTOs;

namespace ProjectManagement.RestAPI.Services.Interfaces;

public interface ITeamService
{
    Task<int> CreateAsync(TeamCreateDto dto);
    Task UpdateAsync(int id, TeamUpdateDto dto);
    Task<ICollection<TeamReadDto>> GetAllAsync();
    Task<TeamReadDto?> GetByIdAsync(int id);
    Task DeleteAsync(int id);
}
