using FluentValidation;
using ProjectManagement.RestAPI.Contracts.Persistence;
using ProjectManagement.RestAPI.DTOs;

namespace ProjectManagement.RestAPI.Validation.WorkTaskValidation;

public class WorkTaskUpdateValidation:AbstractValidator<WorkTaskUpdateDto>
{
    public WorkTaskUpdateValidation(IWorkTaskRepository workTaskRepository)
    {
        
    }
}
