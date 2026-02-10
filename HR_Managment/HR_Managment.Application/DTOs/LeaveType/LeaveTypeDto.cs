using HR_Managment.Application.DTOs.Common;

namespace HR_Managment.Application.DTOs.LeaveType;

public class LeaveTypeDto: BaseDto
{
    public string Name { get; set; }
    public int DefaultDay { get; set; }
}
