using HR_Managment.Application.DTOs.LeaveAllocation;
using HR_Managment.Application.Features.LeaveAllocations.Requests.Commands;
using HR_Managment.Application.Persistence.Contracts;
using MapsterMapper;
using MediatR;

namespace HR_Managment.Application.Features.LeaveAllocations.Handlers.Commands;

public class CreateLeaveAllocationCommandHandler
    : IRequestHandler<CreateLeaveAllocationCommand, int>
{
    private readonly IMapper _mapper;
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;

    public CreateLeaveAllocationCommandHandler(IMapper mapper, ILeaveAllocationRepository leaveAllocationRepository)
    {
        this._mapper = mapper;
        this._leaveAllocationRepository = leaveAllocationRepository;
    }
    public async Task<int> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
    {
        var leaveAllocation = _mapper.Map<LeaveAllocationDto>(request.AllocationDto);
        leaveAllocation = await _leaveAllocationRepository.Add(leaveAllocation);
        return leaveAllocation.Id;
    }
}
