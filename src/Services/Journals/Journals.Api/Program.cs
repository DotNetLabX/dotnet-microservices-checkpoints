using FastEndpoints;
using FastEndpoints.Swagger;
using Journals.Api;
using Journals.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .ConfigureApiOptions(builder.Configuration);

#region Add Services 
builder.Services
    .AddApiServices(builder.Configuration)
    .AddPersistenceServices(builder.Configuration);

#endregion
var app = builder.Build();

#region Use Services
app
    .UseHttpsRedirection()
    .UseRouting()
    .UseFastEndpoints()
    .UseSwaggerGen();
#endregion

app.Run();