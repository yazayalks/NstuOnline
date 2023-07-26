using System.Security.Claims;
using System.Text;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NstuOnline.BFF.Domain.Models;

namespace NstuOnline.BFF.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApiReferences(this IServiceCollection services,
        IConfiguration configuration)
    {
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();
        
        services.AddMediatR(x => x.RegisterServicesFromAssemblies(assemblies));
        services.AddValidatorsFromAssemblies(assemblies);
        services.AddAutoMapper(assemblies);

        services
            .AddSwaggerReferences(configuration)
            .AddAuthenticationReferences(configuration);

        return services;
    }

    private static IServiceCollection AddSwaggerReferences(this IServiceCollection services,
        IConfiguration configuration)
    {
        return services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Nstu Online API", Version = "v1" });
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please enter token",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "bearer"
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
            });
        });
    }

    private static IServiceCollection AddAuthenticationReferences(this IServiceCollection services,
        IConfiguration configuration)
    {
        Token token = configuration.GetSection("token").Get<Token>();
        byte[] secret = Encoding.ASCII.GetBytes(token.Secret);

        services
            .AddAuthentication(
                options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
            .AddJwtBearer(
                options =>
                {
                    options.RequireHttpsMetadata = true;
                    options.SaveToken = true;
                    options.ClaimsIssuer = token.Issuer;
                    options.IncludeErrorDetails = true;
                    options.Validate(JwtBearerDefaults.AuthenticationScheme);
                    options.TokenValidationParameters =
                        new TokenValidationParameters
                        {
                            ClockSkew = TimeSpan.Zero,
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            ValidIssuer = token.Issuer,
                            ValidAudience = token.Audience,
                            IssuerSigningKey = new SymmetricSecurityKey(secret),
                            NameClaimType = ClaimTypes.NameIdentifier,
                            RequireSignedTokens = true,
                            RequireExpirationTime = true
                        };
                });

        return services;
    }
}