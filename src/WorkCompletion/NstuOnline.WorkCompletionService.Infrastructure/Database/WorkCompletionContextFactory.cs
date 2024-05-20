using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace NstuOnline.WorkCompletion.Infrastructure.Database;

public class WorkCompletionContextFactory : IDesignTimeDbContextFactory<WorkCompletionContext>
{
    public WorkCompletionContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<WorkCompletionContext>();
        optionsBuilder.UseNpgsql("User ID=postgres;Password=6969;Host=localhost;Port=5433;Database=NstuOnlineWorkCompletionServiceDb;");

        return new WorkCompletionContext(optionsBuilder.Options);
    }
}