using FluentValidation;
using ProjectManagement.RestAPI.Contracts.Persistence;
using ProjectManagement.RestAPI.DTOs;

namespace ProjectManagement.RestAPI.Validation.UserValidation;

public class UserUpdateValidation:AbstractValidator<UserUpdateDto>
{
    public UserUpdateValidation(IUserRepository userRepository)
    {
        
    }
}
