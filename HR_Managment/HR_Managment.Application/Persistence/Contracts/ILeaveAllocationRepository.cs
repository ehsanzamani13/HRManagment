using HR_Managment.Application.DTOs.LeaveAllocation;

namespace HR_Managment.Application.Persistence.Contracts;

public interface ILeaveAllocationRepository : IGenericeRepository<LeaveAllocationDto>
{
    Task<List<LeaveAllocationDto>> GetLeaveAllocationsWithDetails();
    Task<LeaveAllocationDto> GetLeaveAllocationWithDetails(int id);
}
