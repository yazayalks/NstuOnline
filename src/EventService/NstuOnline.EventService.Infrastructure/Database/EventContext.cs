using Microsoft.EntityFrameworkCore;

namespace NstuOnline.EventService.Infrastructure.Database;

public class EventContext : DbContext
{
    public EventContext(DbContextOptions<EventContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EventContext).Assembly);
    }
}