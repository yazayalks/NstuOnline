using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NstuOnline.MessageService.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Minio.AspNetCore;
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
            .AddMinIoReferences(configuration)
            .AddOpenTelemetryReferences("NstuOnline.MessageService");

        return services;
    }
    
    public static async Task MigrateDatabase<TContext>(this IServiceCollection services)
        where TContext : DbContext
    {
        var context = services.BuildServiceProvider().GetService<TContext>();
        await context.Database.MigrateAsync();
    }

    public static IServiceCollection AddRepositoryReferences(this IServiceCollection services)
    {
        return services
            .AddScoped<IChatRepository, ChatRepository>()
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<IMessageRepository, MessageRepository>()
            .AddScoped<IChatUserRepository, ChatUserRepository>()
            .AddScoped<IAttachmentRepository, AttachmentRepository>()
            .AddScoped<IAttachmentTypeRepository, AttachmentTypeRepository>()
            .AddScoped<IChatTypeRepository, ChatTypeRepository>();
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
                .AddOtlpExporter()
                //.AddConsoleExporter()
            );

        return services;
    }

    public static IServiceCollection AddMinIoReferences(this IServiceCollection services, IConfiguration configuration)
    {
        return services.AddMinio(new Uri(configuration.GetConnectionString("Minio")!));
    }
}