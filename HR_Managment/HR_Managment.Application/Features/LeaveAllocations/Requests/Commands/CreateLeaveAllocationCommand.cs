using HR_Managment.Application.DTOs.LeaveAllocation;
using HR_Managment.Application.Responses;
using MediatR;

namespace HR_Managment.Application.Features.LeaveAllocations.Requests.Commands;

public class CreateLeaveAllocationCommand : IRequest<BaseCommandResponse>
{
    public CreateLeaveAllocationDto AllocationDto { get; set; }
}
