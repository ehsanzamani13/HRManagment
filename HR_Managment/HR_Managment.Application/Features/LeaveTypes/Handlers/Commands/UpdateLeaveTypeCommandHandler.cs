using HR_Managment.Application.Common.Models;
using HR_Managment.Application.Contracts.Persistence;
using HR_Managment.Application.DTOs.LeaveType.Validators;
using HR_Managment.Application.Exceptions;
using HR_Managment.Application.Features.LeaveTypes.Requests.Commands;
using MapsterMapper;
using MediatR;

namespace HR_Managment.Application.Features.LeaveTypes.Handlers.Commands;

public class UpdateLeaveTypeCommandHandler
    : IRequestHandler<UpdateLeaveTypeCommand, Response<Unit>>
{
    private readonly IMapper _mapper;
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public UpdateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
    {
        _mapper = mapper;
        _leaveTypeRepository = leaveTypeRepository;
    }
    public async Task<Response<Unit>> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        #region Validations
        var validation = new CreateLeaveTypeValidator(_leaveTypeRepository);
        var validationResult = await validation.ValidateAsync(request.LeaveTypeDto);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult);
        }
        #endregion

        var leaveType = await _leaveTypeRepository.Get(request.LeaveTypeDto.Id);
        if (leaveType == null)
            return Response<Unit>.Failed("LeaveType not found", 404);

        _mapper.Map(request.LeaveTypeDto, leaveType);
        await _leaveTypeRepository.Update(leaveType);

        return Response<Unit>.Success(Unit.Value);
    }
}