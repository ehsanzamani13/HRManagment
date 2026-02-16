using HR_Managment.Application.Contracts.Persistence;
using HR_Managment.Application.DTOs.LeaveType.Validators;
using HR_Managment.Application.Exceptions;
using HR_Managment.Application.Features.LeaveTypes.Requests.Commands;
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
        #region Validations
        var validation = new CreateLeaveTypeValidator(_leaveTypeRepository);
        var validationResult = await validation.ValidateAsync(request.LeaveTypeDto);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult);
        }
        #endregion

        var leaveType = await _leaveTypeRepository.Get(request.LeaveTypeDto.Id);
        _mapper.Map(request.LeaveTypeDto, leaveType);
        await _leaveTypeRepository.Update(leaveType);

        return Unit.Value;
    }
}