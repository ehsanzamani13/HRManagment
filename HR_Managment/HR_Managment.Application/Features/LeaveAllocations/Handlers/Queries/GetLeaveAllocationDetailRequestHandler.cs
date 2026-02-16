using HR_Managment.Application.Contracts.Persistence;
using HR_Managment.Application.DTOs.LeaveAllocation;
using HR_Managment.Application.Features.LeaveAllocations.Requests.Queries;
using MapsterMapper;
using MediatR;

namespace HR_Managment.Application.Features.LeaveAllocations.Handlers.Queries;

public class GetLeaveAllocationDetailRequestHandler : IRequestHandler<GetLeaveAllocationDetailRequest, LeaveAllocationDto>
{
    private readonly IMapper _mapper;
    private readonly ILeaveAllocationRepository _allocationRepository;

    public GetLeaveAllocationDetailRequestHandler(IMapper mapper , ILeaveAllocationRepository allocationRepository)
    {
        this._mapper = mapper;
        this._allocationRepository = allocationRepository;
    }
    public async Task<LeaveAllocationDto> Handle(GetLeaveAllocationDetailRequest request, CancellationToken cancellationToken)
    {
        var leaveAllocation =  await _allocationRepository.Get(request.Id);
        return _mapper.Map<LeaveAllocationDto>(leaveAllocation);
    }
}
