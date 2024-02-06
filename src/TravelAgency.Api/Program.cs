using FastBubberDinner.Api.Middleware;
using FastEndpoints;
using FastEndpoints.Swagger;
using TravelAgency.Api;
using TravelAgency.Application;
using TravelAgency.Persistence;
using TravelAgency.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPresentation();
builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyPolicy", builder =>
    {
        // TODO: set defaults origins.
        builder.AllowAnyOrigin();
        builder.AllowAnyHeader();
        builder.AllowAnyMethod();
    });
});

var app = builder.Build();
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseCors("MyPolicy");
app.UseAuthentication();
app.UseAuthorization();
app.UseFastEndpoints().UseCors("MyPolicy");
app.UseSwaggerGen();
app.Run();