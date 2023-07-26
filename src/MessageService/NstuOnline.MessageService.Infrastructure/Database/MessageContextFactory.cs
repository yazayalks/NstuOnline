using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace NstuOnline.MessageService.Infrastructure.Database;

internal class MessageContextFactory : IDesignTimeDbContextFactory<MessageContext>
{
    public MessageContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<MessageContext>();
        optionsBuilder.UseNpgsql("User ID=postgres;Password=6969;Host=localhost;Port=5433;Database=NstuOnlineMessageDb;");

        return new MessageContext(optionsBuilder.Options);
    }
}