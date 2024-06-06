using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Minio.AspNetCore;
using Npgsql;
using NstuOnline.FileService.Domain.Contracts;
using NstuOnline.FileService.Infrastructure.Database;
using NstuOnline.FileService.Infrastructure.Database.Repositories;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace NstuOnline.FileService.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureReferences(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<FileContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString(nameof(FileContext))));

        services
            .AddRepositoryReferences()
            .AddMinIoReferences(configuration)
            .AddOpenTelemetryReferences("NstuOnline.FileService");

        return services;
    }

    public static IServiceCollection AddRepositoryReferences(this IServiceCollection services)
    {
        return services
            .AddScoped<IFileRepository, FileRepository>()
            .AddScoped<IFileTypeRepository, FileTypeRepository>();
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
            );

        return services;
    }

    public static IServiceCollection AddMinIoReferences(this IServiceCollection services, IConfiguration configuration)
    {
        return services.AddMinio(new Uri(configuration.GetConnectionString("Minio")!));
    }
}