using HR_Managment.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR_Managment.Persistence.Configurations.Entities;

public class LeaveTypeConfiguration : IEntityTypeConfiguration<LeaveType>
{
    public void Configure(EntityTypeBuilder<LeaveType> builder)
    {
        builder.HasData(
            new LeaveType
            {
                Id = 1,
                Name = "Vacation",
                DefaultDay = 10,
                CreatedBy = "Ehsan"
            },
            new LeaveType
            {
                Id = 2,
                Name = "Sick",
                DefaultDay = 12,
                CreatedBy = "Ehsan"
            },
            new LeaveType
            {
                Id = 3,
                Name = "Maternity",
                DefaultDay = 90,
                CreatedBy = "Ehsan"
            }
            );
    }
}
