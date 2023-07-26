using NstuOnline.MessageService.Application.Extensions;
using NstuOnline.MessageService.Infrastructure.Extensions;
using Serilog;
using Serilog.Sinks.Grafana.Loki;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.GrafanaLoki("http://localhost:3100")
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);



builder.Host.UseSerilog();

builder.Services
    .AddInfrastructureReferences(builder.Configuration)
    .AddApplicationReferences(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();