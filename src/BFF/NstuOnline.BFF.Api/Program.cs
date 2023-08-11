using NstuOnline.BFF.Api.Extensions;
using NstuOnline.BFF.Application.Extensions;
using NstuOnline.BFF.Infrastructure.Extensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Host.UseSerilog();

builder.Services
    .AddInfrastructureReferences(builder.Configuration)
    .AddApplicationReferences(builder.Configuration)
    .AddApiReferences(builder.Configuration);

builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Nstu online API V1");

        options.OAuthClientId("demo_api_swagger");
        options.OAuthAppName("Nstu Online API - Swagger");
        options.OAuthUsePkce();
    });
}

//app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();