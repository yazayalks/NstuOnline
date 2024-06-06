using NstuOnline.EducationalStructureService.Application.Extensions;
using NstuOnline.EducationalStructure.Infrastructure.Database;
using NstuOnline.EducationalStructure.Infrastructure.Extensions;
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

await builder.Services.MigrateDatabase<EducationalStructureContext>();

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();