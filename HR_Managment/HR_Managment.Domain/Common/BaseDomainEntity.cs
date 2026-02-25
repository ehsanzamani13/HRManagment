namespace HR_Managment.Domain.Common;

public class BaseDomainEntity
{
    public int Id { get; set; }
    public DateTime CreateDate { get; set; } = new DateTime();
    public string CreatedBy { get; set; } = null!;
    public DateTime? LastModifiedDate { get; set; }
    public string? LastModifiedBy { get; set; }
}
