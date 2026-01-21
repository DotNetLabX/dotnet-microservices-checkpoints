using Auth.API;
using Auth.Application;
using Auth.Persistence;
using FastEndpoints;
using FastEndpoints.Swagger;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .ConfigureApiOptions(builder.Configuration);

#region Add Services 
builder.Services
    .AddApiServices(builder.Configuration)
    .AddApplicationServices(builder.Configuration)
    .AddPersistenceServices(builder.Configuration);

#endregion
var app = builder.Build();

#region Use Services
app
    .UseHttpsRedirection()
    .UseRouting()
    .UseFastEndpoints()
    .UseSwaggerGen()
    ;
#endregion

app.Run();