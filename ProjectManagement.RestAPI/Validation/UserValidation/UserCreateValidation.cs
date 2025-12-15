using FluentValidation;
using ProjectManagement.RestAPI.Contracts.Persistence;
using ProjectManagement.RestAPI.DTOs;

namespace ProjectManagement.RestAPI.Validation.UserValidation;

public class UserCreateValidation:AbstractValidator<UserCreateDto>
{
    public UserCreateValidation(IUserRepository userRepository)
    {
        RuleFor(u => u.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("A valid email is required.")
            .MustAsync(async (email, cancellation) =>
            {
                var existingUser = await userRepository.GetByEmailAsync(email);
                return existingUser == null;
            }).WithMessage("Email already exists.");
        RuleFor(u => u.FullName)
            .NotEmpty().WithMessage("Full name is required.")
            .MaximumLength(100).WithMessage("Full name cannot exceed 100 characters.");

    }
}
