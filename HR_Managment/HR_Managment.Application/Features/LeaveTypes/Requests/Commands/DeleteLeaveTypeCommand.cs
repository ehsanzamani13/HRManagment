using HR_Managment.Application.Common.Models;
using MediatR;

namespace HR_Managment.Application.Features.LeaveTypes.Requests.Commands;

public class DeleteLeaveTypeCommand : IRequest<Response<Unit>>
{
    public int Id { get; set; }
}
