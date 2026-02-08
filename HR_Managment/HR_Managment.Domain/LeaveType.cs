using HR_Managment.Domain.Common;

namespace HR_Managment.Domain;

public class LeaveType: BaseDomainEntity
{
    public string Name { get; set; }
    public int DefaultDay { get; set; }
}
