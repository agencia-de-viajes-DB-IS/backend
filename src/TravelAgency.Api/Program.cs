using FastBubberDinner.Api.Middleware;
using FastEndpoints;
using FastEndpoints.Swagger;
using TravelAgency.Api;
using TravelAgency.Application;
using TravelAgency.Infrastructure;
using TravelAgency.Infrastructure.Persistence.SeedData;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPresentation();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyPolicy", configurePolicy =>
    {
        // TODO: set defaults origins. 
        configurePolicy.AllowAnyOrigin();
        configurePolicy.AllowAnyHeader();
        configurePolicy.AllowAnyMethod();
    });
});

var app = builder.Build();
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseCors("MyPolicy");
app.UseAuthentication();
app.UseAuthorization();
app.UseFastEndpoints().UseCors("MyPolicy");
app.UseSwaggerGen();
app.EnsurePopulate();
app.Run();