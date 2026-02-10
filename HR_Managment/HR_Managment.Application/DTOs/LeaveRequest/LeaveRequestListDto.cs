using HR_Managment.Application.DTOs.Common;
using HR_Managment.Application.DTOs.LeaveType;

namespace HR_Managment.Application.DTOs.LeaveRequest;

public class LeaveRequestListDto : BaseDto
{
    public LeaveTypeDto LeaveType { get; set; }
    public int LeaveTypeId { get; set; }
    public bool IsApproved { get; set; }
}
