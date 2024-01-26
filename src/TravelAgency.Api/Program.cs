using FastEndpoints;
using FastEndpoints.Swagger;
using TravelAgency.Api;
using TravelAgency.Application;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPresentation();
builder.Services.AddApplication();

var app = builder.Build();

app.UseFastEndpoints();
app.UseSwaggerGen();
app.Run();