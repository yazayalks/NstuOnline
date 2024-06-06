﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using NstuOnline.WorkCompletion.Infrastructure.Database;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace NstuOnline.WorkCompletion.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureReferences(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<WorkCompletionContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString(nameof(WorkCompletionContext))));

        services
            .AddRepositoryReferences()
            .AddOpenTelemetryReferences("NstuOnline.WorkCompletionService");

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
        return services;
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
}