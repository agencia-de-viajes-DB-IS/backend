using FastEndpoints;
using FastEndpoints.Swagger;
using TravelAgency.Api;
using TravelAgency.Application;
using TravelAgency.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPresentation();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

app.UseAuthentication();
app.UseFastEndpoints();
app.UseSwaggerGen();
app.Run();