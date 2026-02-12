using HR_Managment.Application.DTOs.LeaveAllocation;
using MediatR;

namespace HR_Managment.Application.Features.LeaveAllocations.Requests.Commands;

public class UpdateLeaveAllocationCommand : IRequest<Unit>
{
    public LeaveAllocationDto LeaveAllocationDto { get; set; }
}
