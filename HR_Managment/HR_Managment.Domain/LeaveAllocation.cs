namespace HR_Managment.Domain;

public class LeaveAllocation
{
    public int Id { get; set; }
    public int NumberOfDays { get; set; }
    public DateTime CreateDate { get; set; }
    public LeaveType LeaveType { get; set; }
    public int LeaveTypeId { get; set; }
    public int Period { get; set; }
}
