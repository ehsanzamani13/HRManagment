using HR_Managment.Application.DTOs.LeaveAllocation;
using HR_Managment.Application.DTOs.LeaveAllocation.Validators;
using HR_Managment.Application.Exceptions;
using HR_Managment.Application.Features.LeaveAllocations.Requests.Commands;
using HR_Managment.Application.Persistence.Contracts;
using HR_Managment.Application.Responses;
using MapsterMapper;
using MediatR;

namespace HR_Managment.Application.Features.LeaveAllocations.Handlers.Commands;

public class CreateLeaveAllocationCommandHandler
    : IRequestHandler<CreateLeaveAllocationCommand, BaseCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public CreateLeaveAllocationCommandHandler(IMapper mapper,
        ILeaveAllocationRepository leaveAllocationRepository,
        ILeaveTypeRepository leaveTypeRepository
        )
    {
        this._mapper = mapper;
        this._leaveAllocationRepository = leaveAllocationRepository;
        this._leaveTypeRepository = leaveTypeRepository;
    }
    public async Task<BaseCommandResponse> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse();
        #region Validations
        var validation = new CreateLeaveAllocationDtoValidator(_leaveTypeRepository);
        var validationResult = await validation.ValidateAsync(request.AllocationDto);
        if (!validationResult.IsValid)
        {
            //throw new ValidationException(validationResult);
            response.Success = false;
            response.Message = "Creation Failed";
            response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
        }
        #endregion        
        var leaveAllocation = _mapper.Map<LeaveAllocationDto>(request.AllocationDto);
        leaveAllocation = await _leaveAllocationRepository.Add(leaveAllocation);

        response.Success = true;
        response.Message = "Creation Successfull";
        response.Id = leaveAllocation.Id;

        return response;
    }
}