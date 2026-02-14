using FluentValidation;

namespace HR_Managment.Application.DTOs.LeaveType.Validators;

public class CreateLeaveTypeDtoValidator
    : AbstractValidator<CreateLeaveTypeDto>
{
    public CreateLeaveTypeDtoValidator()
    {
        RuleFor(p => p.Name).NotEmpty().WithMessage("{Properties} is requierd.")
            .NotNull()
            .MaximumLength(50).WithMessage("{Properties} must less than {value}");

        RuleFor(p => p.DefaultDay)
            .NotEmpty().WithMessage("{Properties} is requierd.")
            .GreaterThan(0)
            .LessThan(100);
    }
}