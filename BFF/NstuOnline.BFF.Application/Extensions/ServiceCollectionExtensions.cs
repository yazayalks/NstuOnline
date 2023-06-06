using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NstuOnline.BFF.Application.Services;
using NstuOnline.BFF.Domain.Models;

namespace NstuOnline.BFF.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationReferences(this IServiceCollection services,
        IConfiguration configuration)
    {
        
        
        services.Configure<Token>(configuration.GetSection("token"));
        
        services.AddScoped<ITokenService, TokenService>();
        
        return services;
    }
}