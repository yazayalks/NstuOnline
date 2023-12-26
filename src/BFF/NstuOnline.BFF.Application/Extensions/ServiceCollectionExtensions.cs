using Common.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NstuOnline.BFF.Application.Configuration;
using NstuOnline.BFF.Application.Services.AttachmentType;
using NstuOnline.BFF.Application.Services.Chat;
using NstuOnline.BFF.Application.Services.ChatType;
using NstuOnline.BFF.Application.Services.Message;
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

        services
            .AddScoped<ITokenService, TokenService>()
            .AddScoped<IChatService, ChatService>()
            .AddScoped<IMessageService, Services.Message.MessageService>()
            .AddScoped<IAttachmentTypeService, AttachmentTypeService>()
            .AddScoped<IChatTypeService, ChatTypeService>();

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
        services.AddRestEaseClient<IMessageApiClient>(configuration.Url); 
        services.AddRestEaseClient<IAttachmentTypeApiClient>(configuration.Url);
        services.AddRestEaseClient<IChatTypeApiClient>(configuration.Url);

        return services;
    }
}