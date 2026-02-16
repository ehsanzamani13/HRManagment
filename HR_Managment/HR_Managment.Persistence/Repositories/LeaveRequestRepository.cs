using HR_Managment.Application.Contracts.Persistence;
using HR_Managment.Application.DTOs.LeaveRequest;
using HR_Managment.Application.DTOs.LeaveType;
using Microsoft.EntityFrameworkCore;

namespace HR_Managment.Persistence.Repositories;

public class LeaveRequestRepository : GenericRepository<LeaveRequestDto>, ILeaveRequestRepository
{
    private readonly LeaveManagmentDbContext _context;
    public LeaveRequestRepository(LeaveManagmentDbContext context) : base(context)
    {
        _context = context;
    }
    public async Task ChangeApprovalStatus(LeaveRequestDto leaveRequest, bool approvalStatus)
    {
        leaveRequest.IsApproved = approvalStatus;
        _context.Entry(leaveRequest.IsApproved).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
    public async Task<List<LeaveRequestDto>> GetLeaveRequestsWithDetails()
    {
        return await _context.LeaveRequests
            .Include(t => t.LeaveType)
            .Select(x=> new LeaveRequestDto
            {
                Id = x.Id,
                DateActioned = x.DateActioned,
                DateRequested = x.DateRequested,
                LeaveTypeId = x.LeaveTypeId,
                RequestComments = x.RequestComments,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                IsCanceled = x.IsCanceled,
                IsApproved = x.IsApproved,
                LeaveType = new LeaveTypeDto()
                {
                    Id = x.Id,
                    DefaultDay = x.LeaveType.DefaultDay,
                    Name = x.LeaveType.Name,
                }
            })
            .ToListAsync();
    }
    public async Task<LeaveRequestDto?> GetLeaveRequestWithDetails(int id)
    {
        return await _context.LeaveRequests
            .Include(t => t.LeaveType)
            .Select(x => new LeaveRequestDto
            {
                Id = x.Id,
                DateActioned = x.DateActioned,
                DateRequested = x.DateRequested,
                LeaveTypeId = x.LeaveTypeId,
                RequestComments = x.RequestComments,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                IsCanceled = x.IsCanceled,
                IsApproved = x.IsApproved,
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