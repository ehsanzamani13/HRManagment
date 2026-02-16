using HR_Managment.Application.Contracts.Infrastructure;
using HR_Managment.Application.Contracts.Persistence;
using HR_Managment.Application.DTOs.LeaveAllocation;
using HR_Managment.Application.DTOs.LeaveAllocation.Validators;
using HR_Managment.Application.DTOs.LeaveRequest;
using HR_Managment.Application.Features.LeaveRequests.Requests.Commands;
using HR_Managment.Application.Models;
using HR_Managment.Application.Responses;
using MapsterMapper;
using MediatR;

namespace HR_Managment.Application.Features.LeaveRequests.Handlers.Commands;

public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, BaseCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly IEmailSender _emailSender;

    public CreateLeaveRequestCommandHandler(IMapper mapper,
        ILeaveRequestRepository leaveAllocationRepository,
        ILeaveTypeRepository leaveTypeRepository,
        IEmailSender emailSender
        )
    {
        this._mapper = mapper;
        this._leaveRequestRepository = leaveAllocationRepository;
        this._emailSender = emailSender;
    }

    public async Task<BaseCommandResponse> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse();

        var leaveRequest = _mapper.Map<LeaveRequestDto>(request.LeaveRequestDto);
        leaveRequest = await _leaveRequestRepository.Add(leaveRequest);

        response.Success = true;
        response.Message = "Creation Successfull";
        response.Id = leaveRequest.Id;
        
        #region Sending Email 
        var email = new Email()
        {
            To = "ehsan@gmail.com",
            Subject = "Leave Request Submitted",
            Body = $"Your Leave Request For {request.LeaveRequestDto.StartDate} " +
            $"To {request.LeaveRequestDto.EndDate}" +
            $" has been submitted"
        };
        try
        {
            await _emailSender.SendEmail(email);
        }
        catch (Exception ex)
        {
            // ToDo Log
        }
        #endregion

        return response;
    }
}