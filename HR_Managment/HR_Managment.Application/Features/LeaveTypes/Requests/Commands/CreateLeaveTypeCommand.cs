using HR_Managment.Application.DTOs.LeaveType;
using MediatR;

namespace HR_Managment.Application.Features.LeaveTypes.Requests.Commands;

public class CreateLeaveTypeCommand : IRequest<int>
{
    public CreateLeaveTypeDto LeaveTypeDto { get; set; }
}
