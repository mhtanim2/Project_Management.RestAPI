using AutoMapper;
using ProjectManagement.RestAPI.Contracts.Persistence;
using ProjectManagement.RestAPI.DTOs;
using ProjectManagement.RestAPI.Service.Interface;

namespace ProjectManagement.RestAPI.Services;

public class WorkTaskService:IWorkTaskService
{
    private readonly IWorkTaskRepository _workTaskRepository;
    private readonly IMapper _mapper;

    public WorkTaskService(IWorkTaskRepository workTaskRepository, IMapper mapper)
    {
        _workTaskRepository = workTaskRepository;
        _mapper = mapper;
    }

    public Task<int> CreateAsync(WorkTaskCreateDto dto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<WorkTaskReadDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<WorkTaskReadDto?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(int id, WorkTaskUpdateDto dto)
    {
        throw new NotImplementedException();
    }

    public async Task<ICollection<WorkTaskReadDto>> SearchAsync(WorkTaskFilterDto filter)
    {
        var results = await _workTaskRepository.SearchAsync(
            filter.Status,
            filter.AssignedToUserId,
            filter.TeamId,
            filter.DueDateFrom,
            filter.DueDateTo);

        return _mapper.Map<ICollection<WorkTaskReadDto>>(results);
    }
}
