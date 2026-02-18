using HR_Managment.Application.Common.Models;
using HR_Managment.Application.Contracts.Persistence;
using HR_Managment.Application.Exceptions;
using HR_Managment.Application.Features.LeaveTypes.Requests.Commands;
using HR_Managment.Domain;
using MapsterMapper;
using MediatR;

namespace HR_Managment.Application.Features.LeaveTypes.Handlers.Commands;

public class DeleteLeaveTypeCommandHandler
    : IRequestHandler<DeleteLeaveTypeCommand, Response<Unit>>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IMapper _mapper;

    public DeleteLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
    {
        this._leaveTypeRepository = leaveTypeRepository;
        this._mapper = mapper;
    }
    public async Task<Response<Unit>> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        var leaveType = await _leaveTypeRepository.Get(request.Id);
        if (leaveType == null)
            return Response<Unit>.Failed("LeaveType not found", 404);


        await _leaveTypeRepository.Delete(request.Id);
        return Response<Unit>.Success(Unit.Value);
    }
}
