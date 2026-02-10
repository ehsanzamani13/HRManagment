using HR_Managment.Application.DTOs.Common;
using HR_Managment.Application.DTOs.LeaveType;

namespace HR_Managment.Application.DTOs.LeaveRequest;

public class LeaveRequestDto: BaseDto
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public LeaveTypeDto LeaveType { get; set; }
    public int LeaveTypeId { get; set; }
    public DateTime DateActioned { get; set; }
    public DateTime DateRequested { get; set; }
    public bool IsApproved { get; set; }
    public bool IsCanceled { get; set; }
    public string RequestComments { get; set; }

}
