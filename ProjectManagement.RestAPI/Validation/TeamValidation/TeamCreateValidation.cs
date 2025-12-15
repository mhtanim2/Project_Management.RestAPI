using FluentValidation;
using ProjectManagement.RestAPI.Contracts.Persistence;
using ProjectManagement.RestAPI.DTOs;

namespace ProjectManagement.RestAPI.Validation.TeamValidation;

public class TeamCreateValidation:AbstractValidator<TeamCreateDto>
{
    public TeamCreateValidation(ITeamRepository teamRepository)
    {
        RuleFor(t => t.Name)
            .NotEmpty().WithMessage("Team name is required.")
            .MaximumLength(100).WithMessage("Team name must not exceed 100 characters.")
            .MustAsync(async (name, cancellation) =>
            {
                var existingTeams = await teamRepository.GetAsync();
                return !existingTeams.Any(t => t.Name.ToLower() == name.ToLower());
            }).WithMessage("A team with the same name already exists.");

    }
}
