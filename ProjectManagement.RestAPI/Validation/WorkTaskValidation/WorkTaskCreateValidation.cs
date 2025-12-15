using FluentValidation;
using ProjectManagement.RestAPI.Contracts.Persistence;
using ProjectManagement.RestAPI.DTOs;

namespace ProjectManagement.RestAPI.Validation.WorkTaskValidation;

public class WorkTaskCreateValidation:AbstractValidator<WorkTaskCreateDto>
{
    public WorkTaskCreateValidation(IWorkTaskRepository workTaskRepository)
    {
        RuleFor(wt => wt.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(200).WithMessage("Title cannot exceed 200 characters.");
        RuleFor(wt => wt.Description)
            .MaximumLength(1000).WithMessage("Description cannot exceed 1000 characters.");
        RuleFor(wt => wt.DueDate)
            .GreaterThan(DateTime.Now).WithMessage("Due date must be in the future.");
        RuleFor(wt => wt)
            .MustAsync(async (workTask, cancellation) =>
            {
                var existingTask = await workTaskRepository.GetByTitleAsync(workTask.Title);
                return existingTask == null;
            }).WithMessage("A work task with the same title already exists.");
    }
}
