using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NstuOnline.MessageService.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using NstuOnline.MessageService.Domain.Contracts;
using NstuOnline.MessageService.Infrastructure.Database.Repositories;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace NstuOnline.MessageService.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureReferences(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<MessageContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString(nameof(MessageContext))));

        services
            .AddRepositoryReferences()
            .AddOpenTelemetryReferences("NstuOnline.MessageService");

        return services;
    }
    
    public static IServiceCollection AddRepositoryReferences(this IServiceCollection services)
    {
        return services
            .AddScoped<IChatRepository, ChatRepository>();
    }
    
    public static IServiceCollection AddOpenTelemetryReferences(this IServiceCollection services, string serviceName)
    {
        services.AddOpenTelemetry()
            .ConfigureResource(resource => resource
                .AddService(serviceName: serviceName))
            .WithTracing(tracing => tracing
                .AddAspNetCoreInstrumentation()
                .AddHttpClientInstrumentation()
                .AddEntityFrameworkCoreInstrumentation()
                .AddMassTransitInstrumentation()
                .AddSqlClientInstrumentation()
                .AddNpgsql()
                .AddOtlpExporter());

        return services;
    }
}