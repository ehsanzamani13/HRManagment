using HR_Managment.Domain;
using HR_Managment.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace HR_Managment.Persistence;

public class LeaveManagmentDbContext : DbContext
{
    public LeaveManagmentDbContext(DbContextOptions<LeaveManagmentDbContext> options)
        : base(options)
    {
    }
    public DbSet<LeaveType> LeaveTypes { get; set; }
    public DbSet<LeaveRequest> LeaveRequests { get; set; }
    public DbSet<LeaveAllocation> LeaveAllocations { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfigurationsFromAssembly(typeof(LeaveManagmentDbContext).Assembly);
    }
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        AddDateTimeLog();
        return base.SaveChangesAsync(cancellationToken);
    }
    public override int SaveChanges()
    {
        AddDateTimeLog();
        return base.SaveChanges();
    }
    private void AddDateTimeLog()
    {
        foreach (var entry in ChangeTracker.Entries<BaseDomainEntity>())
        {
            entry.Entity.LastModifiedDate = DateTime.Now;
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreateDate = DateTime.Now;
            }
        }
    }
}