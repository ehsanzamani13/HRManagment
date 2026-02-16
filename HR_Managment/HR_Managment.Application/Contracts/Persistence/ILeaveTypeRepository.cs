using HR_Managment.Application.DTOs.LeaveType;

namespace HR_Managment.Application.Contracts.Persistence;

public interface ILeaveTypeRepository : IGenericRepository<LeaveTypeDto>
{
    Task<List<LeaveTypeDto>> GetLeaveTypesWithDetails();
    Task<LeaveTypeDto> GetLeaveTypeWithDetails(int id);
}
