using FastEndpoints;
using FastEndpoints.Swagger;
using TravelAgency.Api;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPresentation();

var app = builder.Build();

app.UseFastEndpoints();
app.UseSwaggerGen();
app.Run();