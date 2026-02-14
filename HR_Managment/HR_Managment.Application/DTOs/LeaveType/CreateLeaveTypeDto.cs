using HR_Managment.Application.DTOs.Common;

namespace HR_Managment.Application.DTOs.LeaveType;

public class CreateLeaveTypeDto : BaseDto, ILeaveTypevalidator
{
    public string Name { get; set; }
    public int DefaultDay { get; set; }
}
