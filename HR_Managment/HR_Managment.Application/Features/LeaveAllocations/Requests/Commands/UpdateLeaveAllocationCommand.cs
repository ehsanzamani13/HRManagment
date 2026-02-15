using HR_Managment.Application.DTOs.LeaveAllocation;
using MediatR;

namespace HR_Managment.Application.Features.LeaveAllocations.Requests.Commands;

public class UpdateLeaveAllocationCommand : IRequest<Unit>
{
    public CreateLeaveAllocationDto LeaveAllocationDto { get; set; }
}
