using Microsoft.EntityFrameworkCore;

namespace NstuOnline.MessageService.Infrastructure.Database;

public sealed class MessageContext : DbContext
{
    public MessageContext(DbContextOptions<MessageContext> options)
        : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MessageContext).Assembly);
    }
}