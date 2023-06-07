



using NstuOnline.MessageService.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);



builder.Services
    .AddInfrastructureReferences(builder.Configuration);

builder.Services.AddInfrastructureReferences(builder.Configuration);

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