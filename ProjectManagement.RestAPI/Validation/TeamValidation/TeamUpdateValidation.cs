using FluentValidation;
using ProjectManagement.RestAPI.Contracts.Persistence;
using ProjectManagement.RestAPI.DTOs;
using ProjectManagement.RestAPI.Repositories;

namespace ProjectManagement.RestAPI.Validation.TeamValidation;

public class TeamUpdateValidation:AbstractValidator<TeamUpdateDto>
{
    public TeamUpdateValidation(ITeamRepository teamRepository)
    {
        
    }

}
