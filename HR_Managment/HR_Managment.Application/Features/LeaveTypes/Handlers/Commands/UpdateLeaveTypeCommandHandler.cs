using HR_Managment.Application.Features.LeaveTypes.Requests.Commands;
using HR_Managment.Application.Persistence.Contracts;
using MapsterMapper;
using MediatR;

namespace HR_Managment.Application.Features.LeaveTypes.Handlers.Commands;

public class UpdateLeaveTypeCommandHandler
    : IRequestHandler<UpdateLeaveTypeCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public UpdateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
    {
        this._mapper = mapper;
        this._leaveTypeRepository = leaveTypeRepository;
    }
    public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        var leaveType = await _leaveTypeRepository.Get(request.LeaveTypeDto.Id);
        _mapper.Map(request.LeaveTypeDto, leaveType);
        await _leaveTypeRepository.Update(leaveType);

        return Unit.Value;
    }
}