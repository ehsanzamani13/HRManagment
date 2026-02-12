using HR_Managment.Application.DTOs.LeaveAllocation;
using MediatR;

namespace HR_Managment.Application.Features.LeaveAllocations.Requests.Commands;

public class CreateLeaveAllocationCommand : IRequest<int>
{
    public CreateLeaveAllocationDto AllocationDto { get; set; }
}
