using HR_Managment.Application.DTOs.LeaveType;
using HR_Managment.Application.Features.LeaveTypes.Requests.Commands;
using HR_Managment.Application.Persistence.Contracts;
using MapsterMapper;
using MediatR;

namespace HR_Managment.Application.Features.LeaveTypes.Handlers.Commands;

public class CreateLeaveTypeCommandHandler
    : IRequestHandler<CreateLeaveTypeCommand, int>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IMapper _mapper;

    public CreateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
    {
        this._leaveTypeRepository = leaveTypeRepository;
        this._mapper = mapper;
    }
    public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        var leaveTypeDto = _mapper.Map<LeaveTypeDto>(request.LeaveTypeDto);
        leaveTypeDto = await _leaveTypeRepository.Add(leaveTypeDto);
        return leaveTypeDto.Id;
    }
}
