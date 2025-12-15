using AutoMapper;
using ProjectManagement.RestAPI.DTOs;
using ProjectManagement.RestAPI.Entities;

namespace ProjectManagement.RestAPI.MappingProfile;

public class WorkTaskMappingProfile:Profile
{
    public WorkTaskMappingProfile()
    {
        CreateMap<WorkTask, WorkTaskReadDto>().ReverseMap();
        CreateMap<WorkTaskCreateDto, WorkTask>();
        CreateMap<WorkTaskUpdateDto, WorkTask>();
    }
}
