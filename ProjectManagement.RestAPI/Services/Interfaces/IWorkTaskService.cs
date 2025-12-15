using ProjectManagement.RestAPI.DTOs;

namespace ProjectManagement.RestAPI.Service.Interface;

public interface IWorkTaskService
{
    Task<int> CreateAsync(WorkTaskCreateDto dto);
    Task UpdateAsync(int id, WorkTaskUpdateDto dto);
    Task<ICollection<WorkTaskReadDto>> GetAllAsync();
    Task<WorkTaskReadDto?> GetByIdAsync(int id);
    Task DeleteAsync(int id);
    Task<ICollection<WorkTaskReadDto>> SearchAsync(WorkTaskFilterDto filter);
}
