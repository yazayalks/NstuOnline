using Microsoft.EntityFrameworkCore;

namespace NstuOnline.WorkCompletion.Infrastructure.Database;

public class WorkCompletionContext : DbContext
{
    public WorkCompletionContext(DbContextOptions<WorkCompletionContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(WorkCompletionContext).Assembly);
    }
}