using AutoMapper;
using ProjectManagement.RestAPI.DTOs;
using ProjectManagement.RestAPI.Entities;

namespace ProjectManagement.RestAPI.MappingProfile;

public class TeamMappingProfile:Profile
{
    public TeamMappingProfile()
    {
        CreateMap<Team, TeamReadDto>().ReverseMap();
        CreateMap<TeamCreateDto,Team>();
        CreateMap<TeamUpdateDto, Team>();
    }
}
