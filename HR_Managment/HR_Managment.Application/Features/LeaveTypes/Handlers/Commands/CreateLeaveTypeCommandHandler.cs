using HR_Managment.Application.Contracts.Persistence;
using HR_Managment.Application.DTOs.LeaveType;
using HR_Managment.Application.DTOs.LeaveType.Validators;
using HR_Managment.Application.Exceptions;
using HR_Managment.Application.Features.LeaveTypes.Requests.Commands;
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
        #region Validations
        var validation = new CreateLeaveTypeValidator(_leaveTypeRepository);
        var validationResult = await validation.ValidateAsync(request.LeaveTypeDto);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult);
        }
        #endregion

        var leaveTypeDto = _mapper.Map<LeaveTypeDto>(request.LeaveTypeDto);
        leaveTypeDto = await _leaveTypeRepository.Add(leaveTypeDto);
        return leaveTypeDto.Id;
    }
}
