using HR_Managment.Application.DTOs.LeaveRequest;
using HR_Managment.Application.Responses;
using MediatR;

namespace HR_Managment.Application.Features.LeaveRequests.Requests.Commands;

public class CreateLeaveRequestCommand : IRequest<BaseCommandResponse>
{
    public LeaveRequestDto LeaveRequestDto { get; set; }
}