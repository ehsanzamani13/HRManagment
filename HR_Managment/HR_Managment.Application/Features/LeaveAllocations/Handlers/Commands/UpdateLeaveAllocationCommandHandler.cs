using FluentValidation;
using HR_Managment.Application.DTOs.LeaveAllocation.Validators;
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
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public UpdateLeaveAllocationCommandHandler(IMapper mapper,
        ILeaveAllocationRepository leaveAllocationRepository,
        ILeaveTypeRepository leaveTypeRepository
        )
    {
        this._mapper = mapper;
        this._leaveAllocationRepository = leaveAllocationRepository;
        this._leaveTypeRepository = leaveTypeRepository;
    }
    public async Task<Unit> Handle(UpdateLeaveAllocationCommand request, CancellationToken cancellationToken)
    {
        #region Validations
        var validatior = new CreateLeaveAllocationDtoValidator(_leaveTypeRepository);
        var validatiorResult = await validatior.ValidateAsync(request.LeaveAllocationDto);
        if (!validatiorResult.IsValid)
        {
            throw new Exception();
        }
        #endregion

        var leaveAllocationDto = await _leaveAllocationRepository.Get(request.LeaveAllocationDto.Id);
        _mapper.Map(request.LeaveAllocationDto, leaveAllocationDto);
        await _leaveAllocationRepository.Update(leaveAllocationDto);

        return Unit.Value;
    }
}