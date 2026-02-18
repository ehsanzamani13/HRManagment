using HR_Managment.Application.Common.Models;
using HR_Managment.Application.DTOs.LeaveType;
using MediatR;

namespace HR_Managment.Application.Features.LeaveTypes.Requests.Commands;

public class UpdateLeaveTypeCommand : IRequest<Response<Unit>>
{
    public CreateLeaveTypeDto LeaveTypeDto { get; set; }
}
