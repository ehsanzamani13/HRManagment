using HR_Managment.Application.Persistence.Contracts;
using FluentValidation;

namespace HR_Managment.Application.DTOs.LeaveAllocation.Validators;

public class CreateLeaveAllocationDtoValidator : AbstractValidator<CreateLeaveAllocationDto>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public CreateLeaveAllocationDtoValidator(ILeaveTypeRepository leaveAllocationRepository)
    {
        this._leaveTypeRepository = leaveAllocationRepository;
        Include(new ILeaveAllocationDtoValidator(_leaveTypeRepository));
    }
}