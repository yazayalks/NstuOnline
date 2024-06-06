using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace NstuOnline.WorkCompletionService.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationReferences(this IServiceCollection services,
        IConfiguration configuration)
    {
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();

        services.AddMediatR(x => x.RegisterServicesFromAssemblies(assemblies));
        services.AddValidatorsFromAssemblies(assemblies);
        services.AddAutoMapper(assemblies);

        services
            .AddSwaggerReferences(configuration);

        return services;
    }

    private static IServiceCollection AddSwaggerReferences(this IServiceCollection services,
        IConfiguration configuration)
    {
        return services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1",
                new OpenApiInfo { Title = "Nstu Online WorkCompletion Service API", Version = "v1" });
        });
    }
}