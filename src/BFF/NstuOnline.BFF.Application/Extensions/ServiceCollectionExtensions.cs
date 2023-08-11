using Common.Models;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NstuOnline.BFF.Application.Configuration;
using NstuOnline.BFF.Application.Services;
using NstuOnline.BFF.Application.Services.Chat;
using NstuOnline.BFF.Application.Services.Token;
using NstuOnline.BFF.Domain.Models;
using NstuOnline.MessageService.ApiClientContracts.ApiClients;
using RestEase.HttpClientFactory;

namespace NstuOnline.BFF.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationReferences(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<Token>(configuration.GetSection("token"));

        services.AddApiClient(configuration);

        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IChatService, ChatService>();


        return services;
    }

    private static IServiceCollection AddApiClient(this IServiceCollection services,
        IConfiguration configuration)
    {
        var webApiClientConfigurations = configuration
            .GetRequiredSection("WebApiClients")
            .Get<ApiClientConfigurations>();

        services.AddMessageApiClient(webApiClientConfigurations.MessageService);

        return services;
    }

    private static IServiceCollection AddMessageApiClient(this IServiceCollection services,
        ApiClientConfiguration configuration)
    {
        services.AddRestEaseClient<IChatApiClient>(configuration.Url);

        return services;
    }
}