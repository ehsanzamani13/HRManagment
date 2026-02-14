using FluentValidation;
using HR_Managment.Application.Persistence.Contracts;

namespace HR_Managment.Application.DTOs.LeaveType.Validators;

public class CreateLeaveTypeValidator : AbstractValidator<CreateLeaveTypeDto>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public CreateLeaveTypeValidator(ILeaveTypeRepository leaveTypeRepository)
    {
        Include(new ILeaveTypeDtoValidator());

        _leaveTypeRepository = leaveTypeRepository;

        RuleFor(p => p.Id)
            .GreaterThan(0)
            .MustAsync(async (int id, CancellationToken token) =>
            {
                return !await _leaveTypeRepository.IsExists(id);
            })
        .WithMessage("{PropertyName} does not exist.}");
    }
}