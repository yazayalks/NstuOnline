using NstuOnline.WorkCompletion.Infrastructure.Database;
using NstuOnline.WorkCompletion.Infrastructure.Extensions;
using NstuOnline.WorkCompletionService.Application.Extensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Host.UseSerilog();

builder.Services
    .AddInfrastructureReferences(builder.Configuration)
    .AddApplicationReferences(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

await builder.Services.MigrateDatabase<WorkCompletionContext>();

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();