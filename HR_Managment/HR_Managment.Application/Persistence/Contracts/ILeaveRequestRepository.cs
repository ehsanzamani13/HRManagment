using HR_Managment.Application.DTOs.LeaveRequest;
using HR_Managment.Domain;

namespace HR_Managment.Application.Persistence.Contracts;

public interface ILeaveRequestRepository : IGenericRepository<LeaveRequestDto>
{
    Task<LeaveRequestDto> GetLeaveRequestWithDetails(int id);
    Task<List<LeaveRequestDto>> GetLeaveRequestsWithDetails();
    Task ChangeApprovalStatus(LeaveRequestDto leaveRequest, bool approvalStatus);
}