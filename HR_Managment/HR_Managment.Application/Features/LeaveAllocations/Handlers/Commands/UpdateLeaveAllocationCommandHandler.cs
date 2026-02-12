using HR_Managment.Application.Features.LeaveAllocations.Requests.Commands;
using HR_Managment.Application.Persistence.Contracts;
using MapsterMapper;
using MediatR;

namespace HR_Managment.Application.Features.LeaveAllocations.Handlers.Commands;

public class UpdateLeaveAllocationCommandHandler
    : IRequestHandler<UpdateLeaveAllocationCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;

    public UpdateLeaveAllocationCommandHandler(IMapper mapper, ILeaveAllocationRepository leaveAllocationRepository)
    {
        this._mapper = mapper;
        this._leaveAllocationRepository = leaveAllocationRepository;
    }
    public async Task<Unit> Handle(UpdateLeaveAllocationCommand request, CancellationToken cancellationToken)
    {
        var leaveAllocationDto = await _leaveAllocationRepository.Get(request.LeaveAllocationDto.Id);
        _mapper.Map(request.LeaveAllocationDto, leaveAllocationDto);
        await _leaveAllocationRepository.Update(leaveAllocationDto);

        return Unit.Value;
    }
}