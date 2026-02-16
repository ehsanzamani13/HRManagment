using HR_Managment.Application.Contracts.Persistence;
using HR_Managment.Application.DTOs.LeaveAllocation;
using HR_Managment.Application.DTOs.LeaveType;
using Microsoft.EntityFrameworkCore;

namespace HR_Managment.Persistence.Repositories;

public class LeaveAllocationRepository : GenericRepository<LeaveAllocationDto>, ILeaveAllocationRepository
{
    private readonly LeaveManagmentDbContext _context;
    public LeaveAllocationRepository(LeaveManagmentDbContext context) : base(context)
    {
        _context = context;
    }
    public async Task<List<LeaveAllocationDto>> GetLeaveAllocationsWithDetails()
    {
        return await _context.LeaveAllocations
            .Include(x => x.LeaveType)
            .Select(x => new LeaveAllocationDto()
            {
                Id = x.Id,
                LeaveTypeId = x.LeaveTypeId,
                NumberOfDays = x.NumberOfDays,
                Period = x.Period,
                LeaveType = new LeaveTypeDto()
                {
                    Id = x.Id,
                    DefaultDay = x.LeaveType.DefaultDay,
                    Name = x.LeaveType.Name,
                }
            })
            .ToListAsync();
    }
    public async Task<LeaveAllocationDto?> GetLeaveAllocationWithDetails(int id)
    {
        return await _context.LeaveAllocations
            .Include(x => x.LeaveType)
            .Select(x => new LeaveAllocationDto()
            {
                Id = x.Id,
                LeaveTypeId = x.LeaveTypeId,
                NumberOfDays = x.NumberOfDays,
                Period = x.Period,
                LeaveType = new LeaveTypeDto()
                {
                    Id = x.Id,
                    DefaultDay = x.LeaveType.DefaultDay,
                    Name = x.LeaveType.Name,
                }
            })
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}