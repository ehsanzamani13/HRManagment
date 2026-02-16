using HR_Managment.Application.DTOs.LeaveAllocation;

namespace HR_Managment.Application.Contracts.Persistence;

public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocationDto>
{
    Task<List<LeaveAllocationDto>> GetLeaveAllocationsWithDetails();
    Task<LeaveAllocationDto> GetLeaveAllocationWithDetails(int id);
}
