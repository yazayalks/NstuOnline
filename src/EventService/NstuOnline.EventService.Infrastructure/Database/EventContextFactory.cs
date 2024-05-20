using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace NstuOnline.EventService.Infrastructure.Database;

public class EventContextFactory : IDesignTimeDbContextFactory<EventContext>
{
    public EventContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<EventContext>();
        optionsBuilder.UseNpgsql("User ID=postgres;Password=6969;Host=localhost;Port=5433;Database=NstuOnlineEventDb;");

        return new EventContext(optionsBuilder.Options);
    }
}