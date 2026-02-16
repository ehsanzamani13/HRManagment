using HR_Managment.Application.DTOs.LeaveType;
using HR_Managment.Application.Persistence.Contracts;
using Microsoft.EntityFrameworkCore;

namespace HR_Managment.Persistence.Repositories;

public class LeaveTypeRepository : GenericRepository<LeaveTypeDto>, ILeaveTypeRepository
{
    private readonly LeaveManagmentDbContext _context;
    public LeaveTypeRepository(LeaveManagmentDbContext context) : base(context)
    {
        _context = context;
    }
    public async Task<List<LeaveTypeDto>> GetLeaveTypesWithDetails()
    {
        return await _context.LeaveTypes
            .Select(x => new LeaveTypeDto
            {
                Id = x.Id,
                DefaultDay = x.DefaultDay,
                Name = x.Name,
            })
            .ToListAsync();
    }
    public async Task<LeaveTypeDto?> GetLeaveTypeWithDetails(int id)
    {
        return await _context.LeaveTypes
            .Select(x => new LeaveTypeDto
            {
                Id = x.Id,
                DefaultDay = x.DefaultDay,
                Name = x.Name,
            })
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}