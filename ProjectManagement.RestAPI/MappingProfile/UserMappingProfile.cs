using AutoMapper;
using ProjectManagement.RestAPI.DTOs;
using ProjectManagement.RestAPI.Entities;

namespace ProjectManagement.RestAPI.MappingProfile;

public class UserMappingProfile:Profile
{
    public UserMappingProfile()
    {
        CreateMap<User, UserReadDto>().ReverseMap();
        CreateMap<UserCreateDto, User>();
        CreateMap<UserUpdateDto, User >();
    }
}
