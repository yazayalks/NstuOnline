using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NstuOnline.MessageService.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace NstuOnline.MessageService.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureReferences(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<MessageContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString(nameof(MessageContext))));

        return services;
    }
}