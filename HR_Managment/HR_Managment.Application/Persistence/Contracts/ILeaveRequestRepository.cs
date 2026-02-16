using HR_Managment.Application.DTOs.LeaveRequest;
using HR_Managment.Domain;

namespace HR_Managment.Application.Persistence.Contracts;

public interface ILeaveRequestRepository : IGenericRepository<LeaveRequestDto>
{
    Task<LeaveRequest> GetLeaveRequestWithDetails();
    Task<List<LeaveRequest>> GetLeaveRequestsWithDetails(int id);
    Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool approvalStatus);
}